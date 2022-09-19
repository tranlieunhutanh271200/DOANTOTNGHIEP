using API.Gateways.Attributes;
using API.Gateways.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using System;
using System.Threading.Tasks;

namespace API.Gateways.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [Identify]
        [HttpGet]
        public async Task<IActionResult> Test([FromQuery] string token)
        {
            return Ok();
        }
        [HttpGet("domain")]
        public async Task<IActionResult> GetDomain()
        {
            var domains = await _identityService.GetDomains();
            return Ok(domains);
        }
        [HttpPost("domain/register")]
        public async Task<IActionResult> RegisterDomain([FromForm] DomainCreateDTO domainCreateDTO)
        {
            var result = await _identityService.CreateDomain(domainCreateDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("domain/{domainId}")]
        public async Task<IActionResult> UpdateDomain(Guid domainId, [FromBody] DomainUpdateDTO domainUpdateDTO)
        {
            var result = await _identityService.UpdateDomain(domainId, domainUpdateDTO);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        //TODO implementation
        [HttpDelete("domain/{domainId}")]
        public async Task<IActionResult> DeleteDomain(Guid domainId)
        {
            var result = await _identityService.DeleteDomain(domainId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        //TODO implementation
        [HttpGet("component")]
        public async Task<IActionResult> GetComponent()
        {
            var components = await _identityService.GetComponents();
            return Ok(components);
        }
        //TODO implementation
        [HttpPost("component")]
        public async Task<IActionResult> CreateComponent([FromBody] ComponentCreateDTO componentCreateDTO)
        {
            return Ok();
        }
        //TODO implementation
        [HttpPut("component/{id}")]
        public async Task<IActionResult> UpdateComponent(Guid id, [FromBody] Component component)
        {
            return Ok();
        }
        //TODO implementation
        [HttpDelete("component/{id}")]
        public async Task<IActionResult> DeleteComponent(Guid id)
        {
            return Ok();
        }
        //TODO implementation
        [HttpGet("account")]
        public async Task<IActionResult> GetAccounts([FromQuery] Guid domainId)
        {
            var accounts = await _identityService.GetAccounts(domainId);
            return Ok(accounts);
        }

    }
}
