using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Course.gRPC.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        public IdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<bool> CreateAccount(Guid accountId, string username, string password, Guid domainId, string email)
        {
            var data = new
            {
                id = accountId,
                username = username,
                domainId = domainId,
                password = password,
                email = email
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("/api/v1/identity", content);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> DeleteAccount(Guid accountId)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/identity/accounts/{accountId}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}