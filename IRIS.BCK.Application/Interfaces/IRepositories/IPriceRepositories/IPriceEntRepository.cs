using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPrice;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
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
        Task<List<Route>> GetPriceWithRoute(); 
        Task<PriceEnt> GetPriceByRouteId(string routeid, ShipmentCategory pcateogry);
        Task<PriceEnt> GetPriceByRouteId2(string routeid, ShipmentCategory scategory, ProductEnum product);
        Task<(double, double, double)> GetShipmentItemWeight(PriceForShipmentItemCommand shipmentCriteria);
        Task<PriceEnt> CheckExistingPrice(CreatePriceCommand shipmentCriteria);  
        Task<PaymentCriteriaCommandResponse> MakePayment(PaymentCriteriaCommand paymentCriteria);   
    } 
}