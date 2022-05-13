using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPrice;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using Microsoft.EntityFrameworkCore;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Price
{
    public class PriceEntRepository : GenericRepository<PriceEnt>, IPriceEntRepository
    {
        public PriceEntRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public Task<PriceEnt> CheckExistingPrice(CreatePriceCommand shipmentCriteria)
        {
            var result = _dbContext.PriceEnt.FirstOrDefault(e => e.Category == shipmentCriteria.Category
           && e.RouteId == shipmentCriteria.RouteId
           && e.UnitWeight == shipmentCriteria.UnitWeight);
            return Task.FromResult(result);
        }

        public async Task<PriceEnt> GetPriceById(string priceid)
        {
            return await _dbContext.PriceEnt.FirstOrDefaultAsync(e => e.Id.ToString() == priceid);
        }

        public async Task<PriceEnt> GetPriceByRouteId(string routeid, ShipmentCategory scategory)
        {
            return await _dbContext.PriceEnt.FirstOrDefaultAsync(e => e.RouteId.ToString() == routeid && e.Category == scategory);
        }       
        
        public async Task<PriceEnt> GetPriceByRouteId2(string routeid, ShipmentCategory scategory, ProductEnum product)
        {
            return await _dbContext.PriceEnt.FirstOrDefaultAsync(e => e.RouteId.ToString() == routeid && e.Category == scategory && e.Product == product);
        }

        public async Task<List<Route>> GetPriceWithRoute()
        {
            var lsRoutes = await _dbContext.Route.Include(s => s.Prices).ToListAsync();
            return lsRoutes;
        }

        public Task<(double, double, double)> GetShipmentItemWeight(PriceForShipmentItemCommand shipmentCriteria)
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

            return Task.FromResult((volume, volumetricWeight, actualWeight));
        }

        public Task<PaymentCriteriaCommandResponse> MakePayment(PaymentCriteriaCommand paymentCriteria)
        {
            if (paymentCriteria.PaymentMethod == PaymentMethod.Wallet)
            {

            }
            else if (paymentCriteria.PaymentMethod == PaymentMethod.PostPaid)
            {

            }
            else if (paymentCriteria.PaymentMethod == PaymentMethod.CreditCard)
            {

            }
            else if (paymentCriteria.PaymentMethod == PaymentMethod.USSD)
            {

            }
            else if (paymentCriteria.PaymentMethod == PaymentMethod.Cash)
            {

            }

            throw new NotImplementedException();
        }
    }
}