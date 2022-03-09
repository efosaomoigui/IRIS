using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips
{
    public class CreateTripCommand : IRequest<CreateTripCommandResponse>
    {
        public Guid Id { get; set; }
        public string TripReference { get; set; }
        public string RouteCode { get; set; }
        public List<Fleet> Fleet { get; set; }
        public List<Manifest> manifest { get; set; }
        public Guid Driver { get; set; }
        public Guid Dispatcher { get; set; }
        public StatusEnum Status { get; set; }
    }
}