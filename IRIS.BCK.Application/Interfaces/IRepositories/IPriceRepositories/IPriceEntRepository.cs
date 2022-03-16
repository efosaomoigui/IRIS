using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories
{
    public interface IPriceEntRepository : IGenericRepository<PriceEnt>
    {
        Task<PriceEnt> GetPriceById(string priceid);

        Task<PriceEnt> GetPriceByRouteId(string routeid);
    }
}