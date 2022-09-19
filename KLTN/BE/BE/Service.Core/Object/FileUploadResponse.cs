using System;

namespace Service.Core.Object
{
    public class FileUploadResponse
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string AbsolutePath { get; set; }
        public string FileType { get; set; }
    }
}
