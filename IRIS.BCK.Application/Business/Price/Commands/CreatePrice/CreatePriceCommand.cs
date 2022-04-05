using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice
{
    public class CreatePriceCommand : IRequest<CreatePriceCommandResponse>
    {
        public Guid Id { get; set; }

        public ShipmentCategory Category { get; set; }
        public Guid RouteId { get; set; }

        public decimal UnitWeight { get; set; }
        public ProductEnum Product { get; set; }
        public decimal PricePerUnit { get; set; }
        public ICollection<Route> Routes { get; set; }
    }
}