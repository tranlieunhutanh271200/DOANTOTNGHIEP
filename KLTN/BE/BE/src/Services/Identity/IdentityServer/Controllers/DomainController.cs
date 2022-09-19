using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Core.Models.DTOs.Identities;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly IDomainService _domainService;
        private readonly IAccountService _accountService;
        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDomain()
        {
            return Ok(await _domainService.GetDomains());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDomain(Guid id)
        {
            return Ok(await _domainService.GetDomain(id));
        }
        [HttpPost]
        public async Task<IActionResult> RegisterDomain([FromBody] DomainCreateDTO domainCreateDTO)
        {
            DomainDTO result = await _domainService.CreateDomain(domainCreateDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDomain([FromRoute] Guid id, [FromBody] DomainUpdateDTO domainUpdateDTO)
        {
            var result = await _domainService.UpdateDomain(id, domainUpdateDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomain([FromRoute] Guid id)
        {
            var result = await _domainService.DeleteDomain(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("{domainId}/accounts/import-accounts")]
        public async Task<IActionResult> ImportAccounts(Guid domainId, [FromForm] IFormFile importFile)
        {
            var result = await _domainService.ImportAccountAsync(domainId, importFile);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("{domainId}/accounts/remove/{accountId}")]
        public async Task<IActionResult> RemoveAccount(Guid id, Guid accountId)
        {
            var result = await _domainService.RemoveAccountAsync(id, accountId);
            return Ok();
        }
        [HttpPut("{id}/[Action]")]
        public async Task<IActionResult> ToggleActivate(Guid id)
        {
            return Ok();
        }
    }
}
