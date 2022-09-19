using AutoMapper;
using CRM.API.Models;
using CRM.API.Persistences;
using CRM.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IRealtimeService _realtimeService;
        private readonly CRMDbContext _db;
        private readonly IMapper _mapper;
        public MessageController(IRealtimeService realtimeService, CRMDbContext db, IMapper mapper)
        {
            _realtimeService = realtimeService;
            _db = db;
            _mapper = mapper;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetConversation([FromQuery] Guid accountId)
        {
            var conversations = await _db.Conversations.Where(x => x.HostId == accountId || x.MemberId == accountId).Include(x => x.Messages.OrderBy(x => x.SentAt)).AsNoTracking().ToListAsync();

            return Ok(_mapper.Map<List<ConversationDTO>>(conversations));
        }
        [HttpGet("realtime")]
        public async Task<IActionResult> RealtimeMessage([FromQuery] Guid accountId)
        {
            var conversations = await _db.Conversations.Where(x => (x.HostId == accountId || x.MemberId == accountId) && x.Messages.Any(m => m.ReceiverId == accountId && !m.IsSeen)).Include(x => x.Messages.Where(m => !m.IsSeen)).ToListAsync();
            return Ok(_mapper.Map<List<ConversationDTO>>(conversations));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SeenMessage([FromRoute] int id, [FromQuery] Guid accountId)
        {
            var conversation = await _db.Conversations.Where(x => x.Id == id).Include(inc => inc.Messages).FirstOrDefaultAsync();
            if (conversation == null)
            {
                return NotFound();
            }
            foreach (var message in conversation.Messages.Where(x => !x.IsSeen && x.ReceiverId == accountId))
            {
                message.IsSeen = true;
            }
            if (await _db.SaveAndPush(accountId))
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPost("{id}/send")]
        public async ValueTask<IActionResult> SendMessage([FromRoute] int id, [FromBody] SendMessageDTO sendMessageDTO)
        {
            Conversation conversation = new Conversation();
            if (sendMessageDTO.DomainId == Guid.Empty)
            {
                return BadRequest();
            }
            if (id != -1)
            {
                conversation = await _db.Conversations.Where(X => X.Id == id).Include(x => x.Messages).FirstOrDefaultAsync();
                if (conversation == null)
                {
                    return BadRequest();
                }
            }
            else
            {
                conversation.MemberFullname = sendMessageDTO.MemberFullname;
                conversation.HostFullname = sendMessageDTO.HostFullname;
                conversation.HostId = sendMessageDTO.SenderId;
                conversation.MemberId = sendMessageDTO.ReceiverId;
                conversation.DomainId = sendMessageDTO.DomainId;
                _db.Conversations.Add(conversation);
            }
            Message msg = _mapper.Map<Message>(sendMessageDTO);
            conversation.Messages.Add(msg);
            if (await _db.SaveChangesAsync() > 0)
            {
                await _realtimeService.SendMessage(sendMessageDTO.ReceiverId);
                await _db.Push(sendMessageDTO.ReceiverId);
                return Ok();
            }
            return NoContent();
        }
    }
}