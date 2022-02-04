using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        Task<bool> CheckRouteNumber(string route);
    }
}