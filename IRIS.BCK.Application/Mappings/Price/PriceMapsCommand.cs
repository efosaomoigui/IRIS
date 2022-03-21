using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Price
{
    public static class PriceMapsCommand
    {
        public static PriceEnt CreatePriceMapsCommand(CreatePriceCommand request)
        {
            return new PriceEnt
            {
                ShipmentCategory = request.ShipmentCategory,
                RouteId = request.RouteId,
                PricePerUnit = request.PricePerUnit,
                UnitWeight = request.UnitWeight,
            };
        }

        public static PriceEnt PriceForShipmentItemMapsCommand(CreatePriceCommand request)
        {
            return new PriceEnt
            {
                //Category = request.Category,
                //RouteId = request.RouteId,
                //PricePerUnit = request.PricePerUnit,
                //UnitWeight = request.UnitWeight,
            };
        }
    }
}