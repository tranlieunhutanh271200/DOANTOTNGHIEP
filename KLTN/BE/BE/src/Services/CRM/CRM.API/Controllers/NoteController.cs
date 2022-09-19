using AutoMapper;
using CRM.API.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.DTOs.CRM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NoteController : ControllerBase
    {
        private readonly CRMDbContext _db;
        private readonly IMapper _mapper;
        public NoteController(CRMDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid accountId)
        {
            var notes = await _db.Notes.Where(x => x.AccountId == accountId).ToListAsync();
            return Ok(notes);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromQuery] Guid accountId, [FromBody] StickyNote noteCreate)
        {
            noteCreate.AccountId = accountId;
            _db.Notes.Add(noteCreate);
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("{noteId}")]
        public async Task<IActionResult> UpdateNote([FromRoute] int noteId, [FromBody] StickyNote noteUpdate)
        {
            StickyNote dbNote = await _db.Notes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (dbNote == null)
            {
                return NotFound();
            }
            dbNote.Content = noteUpdate.Content;
            dbNote.XPosition = noteUpdate.XPosition;
            dbNote.YPosition = noteUpdate.YPosition;
            dbNote.Color = noteUpdate.Color;
            if (await _db.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            StickyNote dbNote = await _db.Notes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (dbNote == null)
            {
                return NotFound();
            }
            _db.Remove(dbNote);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}