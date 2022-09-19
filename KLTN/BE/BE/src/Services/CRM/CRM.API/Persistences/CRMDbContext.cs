using CRM.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Service.Core.Models;
using Service.Core.Models.CRM;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.LogWork;
using Service.Core.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.API.Persistences
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
        {

        }
        public DbSet<Service.Core.Models.LogWork.Task> Tasks { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        public DbSet<AttachedFile> AttachedFiles { get; set; }
        public DbSet<ReferenceReceiver> ReferenceReceivers { get; set; }
        public DbSet<LogTask> LogTasks { get; set; }
        public DbSet<OnlineMeeting> Meetings { get; set; }
        public DbSet<MeetingAttendee> Attendees { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<StudentAbsent> StudentAbsents { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBook> RoomBooks { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<AccessoryBook> AccessoryBooks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<StickyNote> Notes { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service.Core.Models.LogWork.Task>()
                .Property(x => x.Status).HasConversion<string>();
            modelBuilder.Entity<Ticket>()
                .Property(x => x.Status).HasConversion<string>();
            modelBuilder.Entity<Member>()
                .HasKey(x => new { x.ProjectId, x.AccountId });
            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> Push(Guid accountId, string content = "")
        {
            var _httpContextAccessor = this.GetService<IHttpContextAccessor>();
            var realtimeService = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IRealtimeService>();
            if (!string.IsNullOrEmpty(content))
            {
                Notifies.Add(new Notify()
                {
                    AccountId = accountId,
                    Content = content,
                    IsSeen = false,
                });
                await SaveChangesAsync();
            }
            return await realtimeService.PushNotify(accountId);
        }
        public async Task<bool> Call(List<Guid> attendees, Guid meetingId, Guid hostId, string subjectName, string teacherFullname, int teacherSubjectId, int duration)
        {
            var data = new
            {
                attendees = attendees
            };
           
            var _httpContextAccessor = this.GetService<IHttpContextAccessor>();
            var realtimeService = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IRealtimeService>();

            return await realtimeService.StartMeeting(meetingId, hostId, attendees, subjectName, teacherFullname, teacherSubjectId, duration);
        }
        public async Task<bool> SaveAndPush(Guid accountId, CancellationToken cancellationToken = default)
        {
            var _httpContextAccessor = this.GetService<IHttpContextAccessor>();
            var realtimeService = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IRealtimeService>();
            if (await base.SaveChangesAsync(cancellationToken) > 0)
            {
                return await realtimeService.PushNotify(accountId);
            }
            var entries = ChangeTracker.Entries().Where(e => e.Entity is AuditEntity).ToList();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((AuditEntity)entry.Entity).CreatedBy = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "System";
                    ((AuditEntity)entry.Entity).CreatedDate = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    Entry((AuditEntity)entry.Entity).Property(p => p.CreatedBy).IsModified = false;
                    Entry((AuditEntity)entry.Entity).Property(p => p.CreatedDate).IsModified = false;
                    ((AuditEntity)entry.Entity).ModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                    ((AuditEntity)entry.Entity).ModifiedDate = DateTime.Now;
                }
            }
            return false;
        }
    }
}
