using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
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

        Task<PriceEnt> GetPriceByRouteId(string routeid, ShipmentCategory pcateogry);
        Task<double> GetShipmentItemWeight(PriceForShipmentItemCommand shipmentCriteria); 
    }
}