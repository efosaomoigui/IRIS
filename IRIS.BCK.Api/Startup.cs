using IRIS.BCK.Application;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IGroupWayBillManifest;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentGroupWayBill;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRequestRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Infrastructure.Messaging;
using IRIS.BCK.Infrastructure.Persistence;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Fleets;
using IRIS.BCK.Infrastructure.Persistence.Repositories.GroupWayBillManifest;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Monitoring;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Payments;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Price;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Routes;
using IRIS.BCK.Infrastructure.Persistence.Repositories.ServiceCentre;
using IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentGroupWayBill;
using IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentProcessing;
using IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentRequests;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Shipments;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Wallets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace IRIS.BCK.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string ApiCorsPolicy = "_apiCorsPolicy";

        //1. This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(ApiCorsPolicy, builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });

            //adding the authentication handler & configuration (called Scheme) for app.UseAthentication to use
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["SecretKey"])),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization((options) =>
            {
            });

            services.AddApplicationServices(Configuration);
            services.AddMessagingServiceRegistration(Configuration);
            services.AddPersistenceService(Configuration);
            services.AddFileInfrastructureService(Configuration);

            #region Swagger

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "IRIS.BACKEND.Api", Version = "v1" });

                //To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \" Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },new string[] {}
                    }
                });
            });

            #endregion Swagger

            services.AddControllers();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IFleetRepository, FleetRepository>();
            services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
            services.AddScoped<IPriceEntRepository, PriceEntRepository>();
            services.AddScoped<ICollectionCenterRepository, CollectionCenterRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IManifestRepository, ManifestRepository>();
            services.AddScoped<IGroupWayBillRepository, GroupWayBillRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            services.AddScoped<ITrackHistoryRepository, TrackHistoryRepository>();
            services.AddScoped<IShipmentGroupWayBillMapRepository, ShipmentGroupWayBillMapRepository>();
            services.AddScoped<IGroupWayBillManifestMapRepository, GroupWayBillManifestMapRepository>();
            services.AddScoped<IServiceCenterRepository, ServiceCenterRepository>();
            services.AddScoped<IPaymentLogRepository, PaymentLogRepository>();
            services.AddScoped<ISpecialDomesticZonePriceRepository, SpecialDomesticZonePriceRepository>();
            services.AddScoped<INumberEntRepository, NumberEntRepository>();
            services.AddScoped<IShipmentRequestRepository, ShipmentRequestRepository>();
            services.AddIdentity<User, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(25);
                options.User.RequireUniqueEmail = true;
                //options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<IRISDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IRIS.BACKEND.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(ApiCorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}