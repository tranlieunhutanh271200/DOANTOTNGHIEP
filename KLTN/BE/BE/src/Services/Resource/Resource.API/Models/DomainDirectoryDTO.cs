using System;
using System.Collections.Generic;

namespace Resource.API.Models
{
    public class DomainDirectoryDTO
    {
        public int Id { get; set; }
        public Guid DomainId { get; set; }
        public Guid OwnerId { get; set; }
        public string FolderName { get; set; }
        public int ParentId { get; set; }
        public List<DomainDirectoryDTO> ChildDirectories { get; set; }
    }
}