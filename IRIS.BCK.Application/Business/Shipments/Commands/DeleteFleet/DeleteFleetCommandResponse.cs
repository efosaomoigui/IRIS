using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Fleets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteFleet
{
    public class DeleteFleetCommandResponse : BaseResponse
    {
        public DeleteFleetCommandResponse() : base()
        {
        }

        public FleetDto Fleetdto { get; set; }
    }
}