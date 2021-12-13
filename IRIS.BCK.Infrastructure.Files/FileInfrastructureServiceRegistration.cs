using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IFiles.ICsv;
using IRIS.BCK.Infrastructure.FileManagement;
using IRIS.BCK.Infrastructure.Persistence.Repositories;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Shipments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRIS.BCK.Infrastructure.Persistence
{
    public static class FileInfrastructureServiceRegistration 
    {
        public static IServiceCollection AddFileInfrastructureService(this IServiceCollection service, IConfiguration configuration)
        { 
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddScoped<IShipmentRepository, ShipmentRepository>();
            service.AddScoped<ICsvExporter, CsvExporter>();
            return service;
        }

    }
}
