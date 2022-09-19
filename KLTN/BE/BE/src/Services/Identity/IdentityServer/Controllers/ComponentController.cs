using IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Core.Models.DTOs.Identities;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;
        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] Guid domainId)
        {
            if (domainId != Guid.Empty)
            {
                return Ok(await _componentService.GetAllComponentAsync(domainId));
            }
            return Ok(await _componentService.GetAllComponentAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail([FromRoute] Guid id)
        {
            var result = await _componentService.GetComponentAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ComponentCreateDTO component)
        {
            var result = await _componentService.AddComponentAsync(component);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ComponentCreateDTO component)
        {
            var result = await _componentService.UpdatecomponentAsync(id, component);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _componentService.DeleteComponentAsync(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
