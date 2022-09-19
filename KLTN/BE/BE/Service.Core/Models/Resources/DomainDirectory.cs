using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Core.Models.Resources
{
    public class DomainDirectory
    {
        [Key]
        public int Id { get; set; }
        public Guid DomainId { get; set; }
        public Guid OwnerId { get; set; }
        public string FolderName { get; set; }
        public int? ParentDirectoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DomainDirectory ParentDirectory { get; set; }
        public virtual ICollection<DomainDirectory> ChildDirectories { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public DomainDirectory()
        {
            Files = new List<File>();
            ChildDirectories = new List<DomainDirectory>();
        }
    }
}