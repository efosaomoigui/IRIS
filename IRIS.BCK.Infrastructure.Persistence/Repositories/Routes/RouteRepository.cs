using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Routes
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckRouteNumber(string route)
        {
            return true;
        }

        public async Task<Route> GetRouteById(string routeid)
        {
            return _dbContext.Route.FirstOrDefault(e => e.RouteId.ToString() == routeid);
        }
    }
}