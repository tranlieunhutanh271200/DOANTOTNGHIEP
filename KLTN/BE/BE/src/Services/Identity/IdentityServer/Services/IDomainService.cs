using Microsoft.AspNetCore.Http;
using Service.Core.Models.DTOs.Identities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public interface IDomainService
    {
        ValueTask<List<DomainDTO>> GetDomains();
        ValueTask<DomainDTO> GetDomain(Guid id);
        ValueTask<DomainDTO> GetDomain(string domain);
        ValueTask<DomainDTO> CreateDomain(DomainCreateDTO domainCreateDTO);
        ValueTask<bool> ImportAccountAsync(Guid id, IFormFile excelFile);
        ValueTask<bool> RemoveAccountAsync(Guid id, Guid accountId);
        ValueTask<bool> UpdateDomain(Guid id, DomainUpdateDTO domainUpdateDTO);
        ValueTask<bool> DeleteDomain(Guid id);
    }
}
