using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Service.Core.Object;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Gateways.Services
{
    public class InfrastructureService : IInfrastructureService
    {
        private readonly HttpClient _httpClient;
        public InfrastructureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<bool> DeleteFile(Guid fileId)
        {
            var result = await _httpClient.DeleteAsync($"/api/file/{fileId}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> DeleteFile(string filePath)
        {
            var result = await _httpClient.DeleteAsync($"/api/file/physical?filePath={filePath}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public void SendEmail(string to, string fullname, string title, string body)
        {
        }

        public async ValueTask<FileUploadResponse> UploadFile(IFormFile file)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
            var result = await _httpClient.PostAsync("/api/file", form);
            return JsonConvert.DeserializeObject<FileUploadResponse>(await result.Content.ReadAsStringAsync());
        }

    }
}