using AutoMapper;
using IdentityServer.Persistence.Repositories;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using Service.Core.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _componentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ComponentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _componentRepository = unitOfWork.GetRequiredRepository<IComponentRepository, ComponentRepository>();
            _mapper = mapper;
        }
        public async ValueTask<Component> AddComponentAsync(ComponentCreateDTO componentCreateDTO)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                Component component = _mapper.Map<Component>(componentCreateDTO);
                if (await _componentRepository.CheckExistComponentAsync(component))
                {
                    return null;
                }
                await _componentRepository.AddEntity(component);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return component;
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

        }

        public async ValueTask<bool> DeleteComponentAsync(Guid id)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                if (!await _componentRepository.ExistAsync(x => x.Id == id))
                {
                    return false;
                }
                await _componentRepository.DeleteEntity(id);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public async ValueTask<List<Component>> GetAllComponentAsync()
        {
            var components = await _componentRepository.GetAllAsync();
            return components.ToList();
        }

        public async ValueTask<List<Component>> GetAllComponentAsync(Guid domainId)
        {
            var components = await _componentRepository.GetAllAsync(x => x.Domains.Any(x => x.DomainId == domainId));
            return components.ToList();
        }

        public async ValueTask<Component> GetComponentAsync(Guid id)
        {
            return await _componentRepository.GetEntity(id);
        }

        public async ValueTask<Component> UpdatecomponentAsync(Guid id, ComponentCreateDTO component)
        {
            _unitOfWork.CreateTransaction();
            try
            {
                Component dbComponent = await _componentRepository.GetEntity(id);
                _mapper.Map(component, dbComponent);
                await _unitOfWork.SaveChangesAsync();
                _unitOfWork.Commit();
                return dbComponent;
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

        }
    }
}
