using AutoMapper;
using CRM.API.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CRMDbContext _crmDbContext;
        public TicketController(CRMDbContext crmDbContext, IMapper mapper)
        {
            _crmDbContext = crmDbContext;
            _mapper = mapper;
        }
        [HttpGet("owner/{accountId}")]
        public async Task<IActionResult> GetYourTicket([FromRoute] Guid accountId, [FromQuery] TicketStatus status = TicketStatus.NEW)
        {
            if (accountId == Guid.Empty)
            {
                return BadRequest();
            }
            var tickets = await _crmDbContext.Tickets.Where(x => x.OwnerId == accountId && x.Status == status).ToListAsync();

            return Ok(_mapper.Map<List<TicketDTO>>(tickets));
        }
        [HttpGet("supervisor/{teacherId}")]
        public async Task<IActionResult> GetAccountTicket([FromRoute] Guid teacherId, [FromQuery] TicketStatus status = TicketStatus.NEW)
        {
            if (teacherId == Guid.Empty)
            {
                return BadRequest();
            }
            var tickets = await _crmDbContext.Tickets.Where(x => x.SupervisorId == teacherId && x.Status == status).ToListAsync();

            return Ok(_mapper.Map<List<TicketDTO>>(tickets));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail([FromRoute] Guid id)
        {
            Ticket ticket = await _crmDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            switch (ticket.TicketType)
            {
                case TicketType.ABSENT:
                    ticket.StudentAbsent = await _crmDbContext.StudentAbsents.FirstOrDefaultAsync(x => x.TicketId == id);
                    break;
                case TicketType.ACCESSORYBOOK:
                    ticket.AccessoryBook = await _crmDbContext.AccessoryBooks.FirstOrDefaultAsync(x => x.TicketId == id);
                    break;
                case TicketType.ROOMBOOK:
                    ticket.RoomBook = await _crmDbContext.RoomBooks.FirstOrDefaultAsync(x => x.TicketId == id);
                    break;
                default:
                    break;
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] TicketCreateDTO ticketCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Ticket ticket = _mapper.Map<Ticket>(ticketCreateDTO);
            _crmDbContext.Tickets.Add(ticket);
            await _crmDbContext.SaveChangesAsync();
            return Ok(ticket);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(Guid id, [FromBody] TicketUpdateDTO ticketUpdateDTO)
        {
            Ticket dbTicket = await _crmDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);

            if (dbTicket == null || id != ticketUpdateDTO.Id)
            {
                return BadRequest();
            }
            if (dbTicket.IsApproved)
            {
                return NoContent();
            }
            _mapper.Map(ticketUpdateDTO, dbTicket);
            await _crmDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid id)
        {
            Ticket ticket = await _crmDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            _crmDbContext.Remove(ticket);
            await _crmDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
