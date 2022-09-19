using Microsoft.AspNetCore.Http;
using Service.Core.Object;
using System;
using System.Threading.Tasks;

namespace API.Gateways.Services
{
    public interface IInfrastructureService
    {
        ValueTask<FileUploadResponse> UploadFile(IFormFile file);
        void SendEmail(string to, string fullname, string title, string body);
        ValueTask<bool> DeleteFile(Guid fileId);
        ValueTask<bool> DeleteFile(string filePath);
    }
}