using AutoMapper;
using IdentityServer.Persistence;
using IdentityServer.Persistence.Consts;
using IdentityServer.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Service.Core.Extensions;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using Service.Core.Persistence.Interfaces;
using Service.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class DomainService : IDomainService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainRepository _domainRepository;
        private readonly IComponentRepository _componentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IFileService _fileService;
        private readonly IdentityDbContext _db;
        private readonly IResourceService _resourceService;
        public DomainService(IMapper mapper, IUnitOfWork unitOfWork, IdentityDbContext db, IFileService fileService, IResourceService resourceService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _domainRepository = unitOfWork.GetRequiredRepository<IDomainRepository, DomainRepository>();
            _componentRepository = unitOfWork.GetRequiredRepository<IComponentRepository, ComponentRepository>();
            _accountRepository = unitOfWork.GetRequiredRepository<IAccountRepository, AccountRepository>();
            _db = db;
            _fileService = fileService;
            _resourceService = resourceService;
        }

        public async ValueTask<DomainDTO> CreateDomain(DomainCreateDTO domainCreateDTO)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                Domain domain = _mapper.Map<Domain>(domainCreateDTO);
                if (domainCreateDTO.File != null)
                {
                    var result = await _fileService.UploadFile(domainCreateDTO.File);
                    domain.SchoolLogoId = result.Id;
                    domain.SchoolLogoPath = result.FilePath;
                }
                await _domainRepository.AddEntity(domain);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return _mapper.Map<DomainDTO>(domain);
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }

        }

        public async ValueTask<bool> DeleteDomain(Guid id)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                if (!await _domainRepository.ExistAsync(x => x.Id == id))
                {
                    return false;
                }
                await _domainRepository.DeleteEntity(id);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return await _resourceService.RemoveDomainResource(id);
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

        }

        public async ValueTask<DomainDTO> GetDomain(Guid id)
        {
            var domain = await _domainRepository.GetDomainAsync(id);
            if (domain == null)
            {
                return null;
            }
            var mappedDomain = _mapper.Map<DomainDTO>(domain);
            mappedDomain.Components = _mapper.Map<List<DomainComponentDTO>>(await _componentRepository.GetAllAsync(x => x.Domains.Any(c => c.DomainId == domain.Id)));
            return mappedDomain;
        }

        public async ValueTask<DomainDTO> GetDomain(string domainName)
        {
            var domain = await _domainRepository.GetDomainAsync(domainName);
            if (domain == null)
            {
                return null;
            }
            var mappedDomain = _mapper.Map<DomainDTO>(domain);
            mappedDomain.Components = _mapper.Map<List<DomainComponentDTO>>(await _componentRepository.GetAllAsync(x => x.Domains.Any(c => c.DomainId == domain.Id)));
            return mappedDomain;
        }

        public async ValueTask<List<DomainDTO>> GetDomains()
        {
            IEnumerable<Domain> domains = await _domainRepository.GetDomainsAsync();

            var mappedDomains = _mapper.Map<List<DomainDTO>>(domains.Where(x => x.Abbreviation != "admin").ToList());
            foreach (var domain in mappedDomains)
            {
                domain.Components = _mapper.Map<List<DomainComponentDTO>>(await _componentRepository.GetAllAsync(x => x.Domains.Any(x => x.DomainId == domain.Id)));
                if (domain.DomainAdminId != Guid.Empty)
                {
                    domain.DomainAdmin = _mapper.Map<AccountDTO>(await _accountRepository.GetAccount(domain.DomainAdminId));
                }

            };
            return mappedDomains;
        }

        public async ValueTask<bool> ImportAccountAsync(Guid id, IFormFile excelFile)
        {
            Domain domain = await _domainRepository.GetDomainAsync(id);
            if (domain == null)
            {
                return false;
            }
            Role studentRole = await _db.Roles.FirstOrDefaultAsync(x => x.RoleName == RoleConst.SCHOOL_STUDENT);
            _unitOfWork.CreateTransaction();
            try
            {
                if (excelFile != null)
                {
                    var result = await excelFile.ReadExcel();
                    if (result != null)
                    {
                        List<Account> accounts = new List<Account>();
                        var temp = result.Tables["account"];
                        if (temp != null)
                        {
                            foreach (DataRow row in temp.Rows)
                            {
                                double studentId = (double)row["StudentID"];
                                CryptoUtil.MD5.Hash(studentId.ToString(), out var salt, out string hashed);
                                Account account = new Account()
                                {
                                    Username = studentId.ToString(),
                                    HashPassword = hashed,
                                    Salt = salt,
                                    Email = $"{studentId}{domain.SchoolEmail.Substring(domain.SchoolEmail.IndexOf("@"))}",
                                    Domain = domain,
                                    Role = studentRole,
                                };
                                await _accountRepository.AddEntity(account);
                            }
                        }
                        await _unitOfWork.SaveChangesAsync();
                        _unitOfWork.Commit();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }

        }

        public async ValueTask<bool> RemoveAccountAsync(Guid id, Guid accountId)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> UpdateDomain(Guid id, DomainUpdateDTO domainUpdateDTO)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                if (id != domainUpdateDTO.Id)
                {
                    return false;
                }
                Domain dbDomain = await _domainRepository.GetDomainAsync(id);
                if (dbDomain == null)
                {
                    return false;
                }

                _mapper.Map(domainUpdateDTO, dbDomain);
                // if (domainUpdateDTO.SchoolLogo != null)
                // {
                //     var result = await _fileService.UploadFile(domainUpdateDTO.SchoolLogo);
                //     dbDomain.SchoolLogoId = result.Id;
                //     dbDomain.SchoolLogoPath = result.FilePath;
                // }
                if (domainUpdateDTO.DomainAdminId == Guid.Empty)
                {
                    dbDomain.DomainAdminId = null;
                }
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                if (domainUpdateDTO.DomainStatus == DomainStatus.APPROVED.ToString())
                {
                    return await _resourceService.RegisterDomainResource(dbDomain.Id);
                }
                return true;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }

        }
    }
}
