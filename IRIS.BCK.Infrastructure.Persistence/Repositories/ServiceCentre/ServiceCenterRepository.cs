using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.ServiceCentre
{
    public class ServiceCenterRepository : GenericRepository<ServiceCenter>, IServiceCenterRepository
    {
        public ServiceCenterRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}