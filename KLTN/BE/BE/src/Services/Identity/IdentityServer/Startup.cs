using FluentValidation.AspNetCore;
using IdentityServer.Persistence;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service.Core.Configs;
using Service.Core.Persistence;
using Service.Core.Persistence.Interfaces;
using System;
using System.Text;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddDbContext<IdentityDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("IdentityDb")));
            services.Configure<JwtConfig>(Configuration.GetSection("JwtSettings"));
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddControllers().AddFluentValidation();
            services.AddHttpClient<IFileService, FileService>(opt =>
             {
                 opt.BaseAddress = new Uri(Configuration.GetValue<string>("APISettings:FileServer"));
             });
            services.AddHttpClient<IResourceService, ResourceService>(opt =>
            {
                opt.BaseAddress = new Uri(Configuration.GetValue<string>("APISettings:FileServer"));
            });
            services.RegisterPersistences();
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtSettings:TokenSecret").Value)),
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetSection("JwtSettings:Issuer").Value,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
                opt.SaveToken = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IdentityServer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityServer v1"));
            }
            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
