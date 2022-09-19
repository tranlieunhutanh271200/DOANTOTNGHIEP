using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Service.Core.Object;
using Service.Core.Persistence.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Core.Persistence
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public FileService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async ValueTask<FileUploadResponse> UploadFile(IFormFile file)
        {
            using (var multipartFormContent = new MultipartFormDataContent())
            {
                var fileStreamContent = new StreamContent(file.OpenReadStream());
                fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                multipartFormContent.Add(fileStreamContent, name: "file", fileName: file.FileName);

                var response = await _httpClient.PostAsync("/api/file", multipartFormContent);

                FileUploadResponse uploadResponse = JsonConvert.DeserializeObject<FileUploadResponse>(await response.Content.ReadAsStringAsync());

                return uploadResponse;
            }
        }

        public async ValueTask<List<FileUploadResponse>> UploadFiles(params IFormFile[] files)
        {
            List<FileUploadResponse> uploadResponses = new List<FileUploadResponse>();
            foreach (var file in files)
            {
                var result = await UploadFile(file);
                uploadResponses.Add(result);
            }
            return uploadResponses;
        }
    }
}
