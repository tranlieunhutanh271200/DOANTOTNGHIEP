using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.CRM
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }
        public Guid DomainId { get; set; }
        public string Title { get; set; }
        public Guid HostId { get; set; }
        public string HostFullname { get; set; }
        public Guid MemberId { get; set; }
        public string MemberFullname { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public Conversation()
        {
            Messages = new List<Message>();
        }
    }
}