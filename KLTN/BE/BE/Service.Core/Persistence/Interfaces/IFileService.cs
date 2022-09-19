using Microsoft.AspNetCore.Http;
using Service.Core.Object;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Core.Persistence.Interfaces
{
    public interface IFileService
    {
        ValueTask<FileUploadResponse> UploadFile(IFormFile file);
        ValueTask<List<FileUploadResponse>> UploadFiles(params IFormFile[] files);
    }
}
