using System;
using System.Collections.Generic;

namespace CRM.API.Models
{
    public class AutoNotifyDTO
    {
        public string Content { get; set; }
        public List<Guid> Accounts { get; set; }
    }
}