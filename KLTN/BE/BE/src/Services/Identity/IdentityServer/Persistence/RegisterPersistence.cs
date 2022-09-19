using IdentityServer.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Core.Persistence;
using Service.Core.Persistence.Interfaces;

namespace IdentityServer.Persistence
{
    public static class RegisterPersistence
    {
        public static IServiceCollection RegisterPersistences(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<IdentityDbContext>>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDomainService, DomainService>();
            services.AddScoped<IComponentService, ComponentService>();
            services.AddSingleton<ICacheService, InMemoryCacheService>();
            return services;
        }
    }
}
