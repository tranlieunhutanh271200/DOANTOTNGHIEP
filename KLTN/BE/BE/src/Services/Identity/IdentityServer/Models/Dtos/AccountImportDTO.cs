using Microsoft.AspNetCore.Http;

namespace IdentityServer.Models.Dtos
{
    public class AccountImportDTO
    {
        public IFormFile File { get; set; }
    }
}
