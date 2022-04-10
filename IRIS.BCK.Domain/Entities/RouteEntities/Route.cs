using  IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.RouteEntities
{
    public class Route : Auditable
    {
        public Guid RouteId { get; set; }

        public string RouteName { get; set; }

        public string Departure { get; set; }
        public string Destination { get; set; }
        public List<PriceEnt> Prices { get; set; }  
    }
}