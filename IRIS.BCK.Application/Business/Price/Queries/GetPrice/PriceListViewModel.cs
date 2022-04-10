using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetPrice
{
    public class PriceListViewModel
    {
        public PriceCategory Category { get; set; }
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }
        public string ShipmentCategory { get; set; }
        public string Product { get; set; }

        public string Departure { get; set; } 
        public string Destination { get; set; }  
        public string RouteName { get; set; } 
        public double UnitWeight { get; set; }
        public decimal PricePerUnit { get; set; } 
    }
}