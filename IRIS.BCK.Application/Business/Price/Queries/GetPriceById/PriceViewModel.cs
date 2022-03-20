using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceById
{
    public class PriceViewModel
    {
        public PriceCategory Category { get; set; }
        public Guid Id { get; set; }
        public ShipmentCategory ShipmentCategory { get; set; }
        public ProductEnum Product { get; set; }
        public Guid RouteId { get; set; }

        public Route Route { get; set; }
        public int UnitWeight { get; set; }
        public decimal PricePErUnit { get; set; }
    }
}