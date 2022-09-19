using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace IdentityServer.Utils
{
    public static class RegisterUtils
    {
        public static IApplicationBuilder RegisterRequestMiddleware(this IApplicationBuilder builder, IWebHostEnvironment env, IConfiguration configuration)
        {
            return builder;
        }
        public static IApplicationBuilder RegisterResponseMiddleware(this IApplicationBuilder buider, IWebHostEnvironment env, IConfiguration configuration)
        {
            return buider; ;
        }
    }
}
