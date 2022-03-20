using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.EntityEnums;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Price
{
    public class PriceEntRepository : GenericRepository<PriceEnt>, IPriceEntRepository
    {
        public PriceEntRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public Task<PriceEnt> CheckExistingPrice(CreatePriceCommand shipmentCriteria) 
        {
            var result =  _dbContext.PriceEnt.FirstOrDefault(e => e.Category == shipmentCriteria.Category 
            && e.RouteId == shipmentCriteria.RouteId 
            && e.UnitWeight ==shipmentCriteria.UnitWeight);
            return Task.FromResult(result);
        }

        public async Task<PriceEnt> GetPriceById(string priceid)
        {
            return _dbContext.PriceEnt.FirstOrDefault(e => e.Id.ToString() == priceid);
        }

        public async Task<PriceEnt> GetPriceByRouteId(string routeid, ShipmentCategory scategory)
        {
            return _dbContext.PriceEnt.FirstOrDefault(e => e.RouteId.ToString() == routeid && e.Category == scategory);
        }

       public Task<double> GetShipmentItemWeight(PriceForShipmentItemCommand shipmentCriteria)
        {
            //1. get the weight
            var weight = shipmentCriteria.Weight;

            //2. get the volume
            var volume = shipmentCriteria.Length * shipmentCriteria.Breadth * shipmentCriteria.Height; //measurement in cm

            //3. calculate the volumetric weight
            //Volumetric Weight (Kilograms) = [Width x Length x Height] / 6000 (Centimeters)
            var volumetricWeight = volume / 6000;

            //4. return the actual weight
            var actualWeight = weight > volumetricWeight ? weight : volumetricWeight;

            return Task.FromResult(actualWeight);
        }
    }
}