using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resource.API.Models;
using Resource.API.Persistences;
using Service.Core.Models.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Resource.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DomainDirectoryController : ControllerBase
    {
        private readonly ResourceDbContext _db;
        private readonly IMapper _mapper;
        public DomainDirectoryController(ResourceDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetDomainDirectories([FromRoute] Guid id)
        {
            var directoryTree = await _db.DomainDirectories.Where(x => x.DomainId == id).Include(x => x.ChildDirectories).FirstOrDefaultAsync();
            foreach (var subDir in directoryTree.ChildDirectories)
            {
                await LoadChildDirectory(subDir);
            }
            var result = _mapper.Map<DomainDirectoryDTO>(directoryTree);
            return Ok(result);
        }
        private async Task LoadChildDirectory(DomainDirectory parent)
        {
            parent.ChildDirectories = await _db.DomainDirectories.Where(x => x.ParentDirectoryId.HasValue && x.ParentDirectoryId.Value == parent.Id).ToListAsync();
            foreach (var subDir in parent.ChildDirectories)
            {
                await LoadChildDirectory(subDir);
            }
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateDomainDirectory([FromRoute] Guid id, [FromQuery] int parentDirId = 0)
        {
            if (parentDirId != 0)
            {
                DomainDirectory parent = await _db.DomainDirectories.Where(x => x.Id == parentDirId).FirstOrDefaultAsync();
                if (parent == null)
                {
                    return BadRequest();
                }
                if (parent.DomainId != id)
                {
                    return BadRequest();
                }
                DomainDirectory subDomain = new DomainDirectory
                {
                    DomainId = id,
                    FolderName = "New Folder",
                    ParentDirectory = parent,
                };
                parent.ChildDirectories.Add(subDomain);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
                return NoContent();
            }
            DomainDirectory domainDirectory = new DomainDirectory
            {
                DomainId = id,
                FolderName = "Root",
            };
            _db.Add(domainDirectory);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDirectory([FromRoute] int id, [FromQuery] string folderName)
        {
            DomainDirectory directory = await _db.DomainDirectories.FirstOrDefaultAsync(x => x.Id == id);
            if (directory == null)
            {
                return NotFound();
            }
            directory.FolderName = folderName;
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectory([FromRoute] int id)
        {
            DomainDirectory directory = await _db.DomainDirectories.FirstOrDefaultAsync(x => x.Id == id);
            if (directory == null)
            {
                return NotFound();
            }
            _db.Remove(id);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("domain/{id}")]
        public async Task<IActionResult> RemoveDomainDirectoris([FromRoute] Guid id)
        {
            var directories = await _db.DomainDirectories.Where(x => x.DomainId == id).ToListAsync();
            _db.RemoveRange(directories);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}