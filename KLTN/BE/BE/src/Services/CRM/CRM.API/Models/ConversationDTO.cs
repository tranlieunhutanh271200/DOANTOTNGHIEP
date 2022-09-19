using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class ConversationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Guid HostId { get; set; }
        public Guid MemberId { get; set; }
        public string HostFullname { get; set; }
        public string MemberFullname { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}