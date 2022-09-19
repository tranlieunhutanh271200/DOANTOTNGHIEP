using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Gateways.Attributes
{
    public class IdentifyAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        public IdentifyAttribute()
        {
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _httpClient = context.HttpContext.RequestServices.GetRequiredService<HttpClient>();
            _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            HttpContext httpContext = context.HttpContext;
            httpContext.Request.Headers.TryGetValue("Authorization", out var value);
            if (string.IsNullOrEmpty(value))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"{value}");
                HttpResponseMessage authenticateRequest = await _httpClient.GetAsync(_configuration.GetValue<string>("APISettings:IdentityAPI") + "/api/v1/identity/auth");
                if (authenticateRequest.StatusCode == HttpStatusCode.Unauthorized)
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
