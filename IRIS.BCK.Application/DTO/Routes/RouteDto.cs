using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Routes
{
    public class RouteDto
    {
        public Guid RouteId { get; set; }

        public string RouteName { get; set; }

        public string Departure { get; set; }
        public string Destination { get; set; }

        public ICollection<PriceEnt> Price { get; set; }
    }
}