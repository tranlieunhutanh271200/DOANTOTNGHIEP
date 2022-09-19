using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Gateways.Middlewares
{
    public class AuthenticateMiddleware : IMiddleware
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public AuthenticateMiddleware(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Request.Headers.TryGetValue("Authorization", out var value);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {value.ToString()}");
            HttpResponseMessage authenticateRequest = await _httpClient.GetAsync(_configuration.GetValue<string>("APISettings:IdentityAPI") + "/api/v1/identity/auth");
            if (authenticateRequest.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Unauthorized access");
            }
            await next(context);
        }
    }
}
