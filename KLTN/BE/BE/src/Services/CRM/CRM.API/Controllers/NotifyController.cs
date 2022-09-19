using CRM.API.Models;
using CRM.API.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Core.Models.CRM;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NotifyController : ControllerBase
    {
        private readonly CRMDbContext _db;
        public NotifyController(CRMDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotify([FromBody] NotifyDTO notifyDTO)
        {
            Notify notify = new Notify
            {
                AccountId = notifyDTO.AccountId,
                Content = notifyDTO.Content,
                CreatedAt = DateTime.Now
            };
            _db.Notifies.Add(notify);
            if (await _db.SaveAndPush(notifyDTO.AccountId))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("auto")]
        public async Task<IActionResult> AutoNotify([FromBody] AutoNotifyDTO auto)
        {
            foreach (var account in auto.Accounts)
            {
                Notify notify = new Notify
                {
                    AccountId = account,
                    Content = auto.Content,
                    CreatedAt = DateTime.Now
                };
                _db.Add(notify);
            }
            if (await _db.SaveChangesAsync() > 0)
            {
                foreach (var account in auto.Accounts)
                {
                    await _db.Push(account);
                }
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetNotification([FromQuery] Guid accountId)
        {
            var notification = await _db.Notifies.Where(x => x.AccountId == accountId && !x.IsSeen).ToListAsync();
            return Ok(notification);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> SeenNotification([FromRoute] int id, [FromQuery] Guid accountId)
        {
            var notification = await _db.Notifies.Where(x => x.AccountId == accountId && x.Id == id && !x.IsSeen).FirstOrDefaultAsync();
            if (notification == null)
            {
                return NotFound();
            }
            notification.IsSeen = true;
            if (await _db.SaveAndPush(accountId))
            {
                return Ok();
            }
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> SeenNotifications([FromQuery] Guid accountId)
        {
            var notification = await _db.Notifies.Where(x => x.AccountId == accountId && !x.IsSeen).ToListAsync();
            foreach (var notify in notification)
            {
                notify.IsSeen = true;
            }
            await _db.SaveAndPush(accountId);
            return Ok(notification);
        }
    }
}