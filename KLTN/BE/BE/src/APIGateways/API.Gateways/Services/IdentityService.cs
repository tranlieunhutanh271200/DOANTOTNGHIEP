using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Service.Core.Models.DTOs.Gateway;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.Gateways.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public IdentityService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async ValueTask<bool> CreateComponent(ComponentCreateDTO componentCreateDTO)
        {
            return true;
        }

        public async ValueTask<bool> CreateDomain(DomainCreateDTO domainCreateDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(domainCreateDTO), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("api/v1/domain", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<bool> DeleteAccount(Guid id)
        {
            return true;
        }

        public async ValueTask<bool> DeleteComponent(Guid id)
        {
            return true;
        }

        public async ValueTask<bool> DeleteDomain(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/v1/domain/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async ValueTask<List<AccountDTO>> GetAccounts(Guid domainId)
        {
            var rawResponse = await _httpClient.GetAsync($"api/{_configuration.GetValue<string>("APISettings:IdentityAPIVersion")}/account?domainId=${domainId}");

            List<AccountDTO> accounts = JsonConvert.DeserializeObject<List<AccountDTO>>(await rawResponse.Content.ReadAsStringAsync());
            return accounts;
        }

        public async ValueTask<List<Component>> GetComponents()
        {

            var rawResponse = await _httpClient.GetAsync($"api/{_configuration.GetValue<string>("APISettings:IdentityAPIVersion")}/component");

            List<Component> components = JsonConvert.DeserializeObject<List<Component>>(await rawResponse.Content.ReadAsStringAsync());
            return components;
        }

        public async ValueTask<DomainDTO> GetDomain(Guid domainId)
        {
            var result = await _httpClient.GetAsync($"api/v1/domain/{domainId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<DomainDTO>(await result.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async ValueTask<List<DomainDTO>> GetDomains()
        {
            var rawResponse = await _httpClient.GetAsync($"api/{_configuration.GetValue<string>("APISettings:IdentityAPIVersion")}/domain");

            List<DomainDTO> domains = JsonConvert.DeserializeObject<List<DomainDTO>>(await rawResponse.Content.ReadAsStringAsync());
            return domains;
        }

        public async ValueTask<AuthenticateDTO> Login(string domain, string username, string password)
        {
            var rawResponse = await _httpClient.GetAsync($"api/{_configuration.GetValue<string>("APISettings:IdentityAPIVersion")}/identity/login?domain={domain}&username={username}&password={password}");

            AuthenticateDTO authenticateDTO = JsonConvert.DeserializeObject<AuthenticateDTO>(await rawResponse.Content.ReadAsStringAsync());

            return authenticateDTO;
        }

        public async ValueTask Test(string token)
        {
            var rawResponse = await _httpClient.GetAsync($"api/{_configuration.GetValue<string>("APISettings:IdentityAPIVersion")}/identity/auth");
        }

        public async ValueTask<bool> UpdateAccount(Guid id, AccountDTO accountDTO)
        {
            return true;
        }

        public async ValueTask<bool> UpdateComponent(Guid id, ComponentCreateDTO componentCreateDTO)
        {
            return true;
        }

        public async ValueTask<bool> UpdateDomain(Guid id, DomainUpdateDTO domainUpdateDTO)
        {
            var content = new StringContent(JsonConvert.SerializeObject(domainUpdateDTO), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"api/v1/domain/{id}", content);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
