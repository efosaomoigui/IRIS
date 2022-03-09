using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetById
{
    public class GetFleetByIdQuery : IRequest<FleetViewModel>
    {
        public Guid FleetId { get; set; }

        public GetFleetByIdQuery(string fleetid)
        {
            Guid FleetGuid = new Guid(fleetid);
            FleetId = FleetGuid;
        }
    }
}