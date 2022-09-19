using AutoMapper;
using IdentityServer.Models.Dtos;
using IdentityServer.Persistence;
using IdentityServer.Persistence.Consts;
using IdentityServer.Persistence.Repositories;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using Service.Core.Persistence.Interfaces;
using Service.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainRepository _domainRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IdentityDbContext _db;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IdentityDbContext db)
        {
            _unitOfWork = unitOfWork;
            _domainRepository = unitOfWork.GetRequiredRepository<IDomainRepository, DomainRepository>();
            _accountRepository = unitOfWork.GetRequiredRepository<AccountRepository, AccountRepository>();
            _mapper = mapper;
            _db = db;
        }

        public async ValueTask<bool> CreateAccount(Guid id, string email, string username, string password, Guid domainId)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                CryptoUtil.MD5.Hash(password, out var salt, out string hashed);
                Domain domain = await _domainRepository.GetDomainAsync(domainId);
                Account account = new Account
                {
                    Id = id,
                    Email = email.IndexOf("@") == -1 ? $"{email}@{domain.SchoolEmail.Substring(domain.SchoolEmail.IndexOf("@") + 1)}" : email,
                    Username = username.Replace(" ", ""),
                    HashPassword = hashed,
                    Salt = salt,
                    DomainId = domainId,
                };
                account.Role = await _db.Roles.FirstOrDefaultAsync(x => x.RoleName == RoleConst.SCHOOL_STUDENT);
                await _accountRepository.AddEntity(account);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                _unitOfWork.Rollback();
                return false;
            }

        }

        public async ValueTask<bool> DeleteAccount(string email)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> DeleteAccount(Guid accountId)
        {
            return await _accountRepository.DeleteEntity(accountId) != null;
        }

        public ValueTask<TokenResponseDTO> GenerateToken(string email)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Option<AccountDTO>> GetAccount(Guid domainId, Guid accountId)
        {
            var getDomain = _domainRepository.GetDomainAsync(domainId);

            var getAccount = _accountRepository.GetAccount(accountId);

            var domain = await getDomain;
            if (domain == null)
            {
                return null;
            }
            var account = await getAccount;
            if (account.DomainId != domainId)
            {
                return null;
            }
            return _mapper.Map<AccountDTO>(account);
        }

        public async ValueTask<AccountDTO> GetAccount(string domainName, string username, string refreshToken)
        {
            var account = await _accountRepository.GetAccount(domainName, username, refreshToken);
            var domain = await _domainRepository.GetDomainAsync(domainName);
            var mappedAccount = _mapper.Map<AccountDTO>(account);
            mappedAccount.Domain = _mapper.Map<DomainDTO>(domain);
            return mappedAccount;
        }

        public async ValueTask<AccountDTO> GetAccount(string domainName, string username)
        {
            var account = await _accountRepository.GetAccount(domainName, username);
            var domain = await _domainRepository.GetDomainAsync(domainName);
            var mappedAccount = _mapper.Map<AccountDTO>(account);
            mappedAccount.Domain = _mapper.Map<DomainDTO>(domain);
            return mappedAccount;
        }

        public async ValueTask<List<AccountDTO>> GetAccountsAsync(Guid domainId)
        {
            var accounts = await _accountRepository.GetAllWithIncludesAsync(x => x.DomainId == domainId, inc => inc.Role);
            accounts = accounts.OrderByDescending(x => x.Role.RoleName).ToList();
            return _mapper.Map<List<AccountDTO>>(accounts);
        }

        public ValueTask<bool> LockAccount(string email, TimeSpan lockTo)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Option<AccountDTO>> Register(string email, string password)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> UnlockAccount(string email)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> UpdateRefreshToken(Guid accountId, string refreshToken)
        {
            try
            {
                var account = await _accountRepository.GetEntity(accountId);
                if (account == null)
                {
                    return false;
                }
                account.RefreshToken = refreshToken;
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return true;
            }
            catch (System.Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }

        }
    }
}
