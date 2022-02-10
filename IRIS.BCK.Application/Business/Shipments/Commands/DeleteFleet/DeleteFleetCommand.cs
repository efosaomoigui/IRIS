using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteFleet
{
    public class DeleteFleetCommand : IRequest<DeleteFleetCommandResponse>
    {
        public int FleetId { get; set; }
    }
}