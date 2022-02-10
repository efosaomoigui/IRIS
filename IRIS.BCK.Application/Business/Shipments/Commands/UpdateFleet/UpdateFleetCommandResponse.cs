using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Fleets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateFleet
{
    public class UpdateFleetCommandResponse : BaseResponse
    {
        public UpdateFleetCommandResponse() : base()
        {
        }

        public FleetDto Fleetdto { get; set; }
    }
}