using IRIS.BCK.Core.Application.Interfaces.IMessage;
using IRIS.BCK.Infrastructure.Persistence.Messaging.Emails;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRIS.BCK.Infrastructure.Messaging
{
    public static class InfrastrucureMessagingRegistration
    {
        public static IServiceCollection AddMessagingServiceRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>(); 

            return services;
        }
    }
}
