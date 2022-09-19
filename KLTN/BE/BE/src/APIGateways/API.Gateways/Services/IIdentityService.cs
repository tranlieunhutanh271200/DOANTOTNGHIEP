using Service.Core.Models.DTOs.Gateway;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Gateways.Services
{
    public interface IIdentityService
    {
        ValueTask<AuthenticateDTO> Login(string domain, string username, string password);
        ValueTask<List<DomainDTO>> GetDomains();
        ValueTask<DomainDTO> GetDomain(Guid domainId);
        ValueTask<bool> CreateDomain(DomainCreateDTO domainCreateDTO);
        ValueTask<bool> UpdateDomain(Guid id, DomainUpdateDTO domainUpdateDTO);
        ValueTask<bool> DeleteDomain(Guid id);
        ValueTask<List<Component>> GetComponents();
        ValueTask<bool> CreateComponent(ComponentCreateDTO componentCreateDTO);
        ValueTask<bool> UpdateComponent(Guid id, ComponentCreateDTO componentCreateDTO);
        ValueTask<bool> DeleteComponent(Guid id);
        ValueTask<List<AccountDTO>> GetAccounts(Guid domainId);
        ValueTask<bool> UpdateAccount(Guid id, AccountDTO accountDTO);
        ValueTask<bool> DeleteAccount(Guid id);
        ValueTask Test(string token);
    }
}
