using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.DeleteServiceCenter
{
    public class DeleteServiceCenterCommand : IRequest<DeleteServiceCenterCommandResponse>
    {
        public Guid ServiceCenterId { get; set; }
    }
}