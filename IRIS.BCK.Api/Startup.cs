using IRIS.BCK.Application;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Infrastructure.Messaging;
using IRIS.BCK.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IRIS.BCK.Api
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
            //adding the authentication handler to the service container
            services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", option => {
                option.Cookie.Name = "MyCookieAuth"; 
            });

            services.AddApplicationServices(Configuration);
            services.AddMessagingServiceRegistration(Configuration);
            services.AddPersistenceService(Configuration);
            services.AddFileInfrastructureService(Configuration); 

            services.AddControllers();

            services.AddCors(options => {
                options.AddPolicy("IrisCors", builder => builder.WithOrigins("http://localhost").AllowAnyMethod());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IRIS.BCK.Api", Version = "v1" });
            });

            services.AddIdentity<User, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<IRISDbContext>();

            services.AddHttpClient("IRISAPI", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44323/");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IRIS.BCK.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("IrisCors");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
