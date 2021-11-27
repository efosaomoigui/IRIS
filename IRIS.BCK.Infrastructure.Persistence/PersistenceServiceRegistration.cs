using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Infrastructure.Persistence.Repositories;
using IRIS.BCK.Infrastructure.Persistence.Repositories.Shipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<IRISDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("IRISDbConnection")));
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddScoped<IShipmentRepository, ShipmentRepository>();
            return service;
        }

    }
}
