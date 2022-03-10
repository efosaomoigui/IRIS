using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories
{
    public interface IServiceCenterRepository : IGenericRepository<ServiceCenter>
    {
    }
}