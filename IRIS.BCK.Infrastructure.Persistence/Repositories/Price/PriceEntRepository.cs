using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Price
{
    public class PriceEntRepository : GenericRepository<PriceEnt>, IPriceEntRepository
    {
        public PriceEntRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PriceEnt> GetPriceById(string priceid)
        {
            return _dbContext.PriceEnt.FirstOrDefault(e => e.Id.ToString() == priceid);
        }

        public async Task<PriceEnt> GetPriceByRouteId(string routeid)
        {
            return _dbContext.PriceEnt.FirstOrDefault(e => e.RouteId.ToString() == routeid);
        }
    }
}