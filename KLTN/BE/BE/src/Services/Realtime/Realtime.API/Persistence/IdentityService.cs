using LanguageExt;
using Newtonsoft.Json;
using Service.Core.Models.Identities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Realtime.API.Persistence
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        public IdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async ValueTask<Option<Account>> GetAccount(Guid domainId, Guid accountId)
        {
            var result = await _httpClient.GetAsync($"/{domainId}/{accountId}");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Account account = JsonConvert.DeserializeObject<Account>(await result.Content.ReadAsStringAsync());
                return account;
            }
            return null;
        }
    }
}
