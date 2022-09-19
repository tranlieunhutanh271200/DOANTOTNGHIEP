using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IComponentService
    {
        ValueTask<List<Component>> GetAllComponentAsync();
        ValueTask<List<Component>> GetAllComponentAsync(Guid domainId);
        ValueTask<Component> GetComponentAsync(Guid id);
        ValueTask<Component> AddComponentAsync(ComponentCreateDTO component);
        ValueTask<Component> UpdatecomponentAsync(Guid id, ComponentCreateDTO component);
        ValueTask<bool> DeleteComponentAsync(Guid id);
    }
}
