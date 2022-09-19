using Course.gRPC.Persistence;
using Course.gRPC.Persistence.Seeders;
using Course.gRPC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Core.Persistence.Interfaces;
using System;

namespace Course.gRPC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ISeeder, CourseSeeder>();
            services.AddDbContext<CourseDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CourseDb")));
            services.AddHttpClient<IIdentityService, IdentityService>(opt =>
           {
               opt.BaseAddress = new Uri(Configuration.GetValue<string>("APISettings:IdentityAPI"));
           });
            services.AddHttpClient<IHubService, HubService>(opt =>
            {
                opt.BaseAddress = new Uri(Configuration.GetValue<string>("APISettings:HubAPI"));
            });
            services.AddLogging();
            services.AddAutoMapper(typeof(Startup));
            services.AddGrpc();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<SubjectService>();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
