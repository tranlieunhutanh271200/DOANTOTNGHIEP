using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Core.Persistence;
using Service.Core.Persistence.Interfaces;
using Service.Core.Persistence.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCustomization.Services;

namespace UserCustomization.Persistence
{
    public static class Register
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration configuration){
            services.AddDbContext<CustomizationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("CustomizationDatabase")));
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork<CustomizationDbContext>>();
            services.AddScoped<ISeeder, CustomizationSeeder>();
            services.AddScoped<ICustomizationService, CustomizationService>();
            return services;
        }
    }
}
