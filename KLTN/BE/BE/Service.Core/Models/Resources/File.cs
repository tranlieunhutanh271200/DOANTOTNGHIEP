namespace Service.Core.Models.Resources
{
    public class File : AuditEntity
    {
        public string FilePath { get; set; }
        public string AbsolutePath { get; set; }
        public string FileName { get; set; }
        public int? DirectoryId { get; set; }
        public string FileType { get; set; } = "pdf";
        public virtual DomainDirectory Directory { get; set; }
    }
}
