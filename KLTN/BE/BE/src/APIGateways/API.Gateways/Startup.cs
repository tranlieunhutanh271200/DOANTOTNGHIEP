using API.Gateways.Services;
using Course.gRPC.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace API.Gateways
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
            services.AddHttpClient<IIdentityService, IdentityService>(opt => opt.BaseAddress = new Uri(Configuration.GetSection("APISettings:IdentityAPI").Value));
            services.AddGrpcClient<SubjectProtoService.SubjectProtoServiceClient>(opt =>
            {
                opt.Address = new Uri(Configuration.GetValue<string>("gRPCSettings:CourseServer"));
            });
            services.AddHttpClient<IInfrastructureService, InfrastructureService>(
                opt => opt.BaseAddress = new Uri(Configuration.GetValue<string>("APISettings:ResourceAPI")));
            services.AddHttpClient<ICRMService, CRMService>(opt => opt.BaseAddress = new Uri(Configuration.GetValue<string>("APISettings:CRMAPI")));
            services.AddScoped<SubjectGrpcService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API.Gateways", Version = "v1" });
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = null; // if don't set default value is: 30 MB
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API.Gateways v1"));
            }
            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
