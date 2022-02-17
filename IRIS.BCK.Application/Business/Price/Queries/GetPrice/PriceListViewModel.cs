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

        public int RouteId { get; set; }

        public Route Route { get; set; }
        public int UnitWeight { get; set; }
        public decimal PricePErUnit { get; set; }
    }
}