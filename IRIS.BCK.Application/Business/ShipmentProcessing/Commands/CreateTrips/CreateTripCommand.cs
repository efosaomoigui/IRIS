using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
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
        public string Fleet { get; set; }
        public string Driver { get; set; }        
        public Fleet FleetObj { get; set; }
        public User DriverObj { get; set; }
        public List<ManifestListViewModel> ManifestList { get; set; }   
        public Guid Dispatcher { get; set; }
        public Guid ManifestId { get; set; } 
    }
}