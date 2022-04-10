using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.PriceEntities
{
    public class PriceEnt : Auditable
    {
        public Guid Id { get; set; }
        public ShipmentCategory Category { get; set; }
        public double UnitWeight { get; set; }
        public ProductEnum Product { get; set; }
        public decimal PricePerUnit { get; set; }

        public Guid RouteId { get; set; } 
        public Route Route { get; set; }
    }
}