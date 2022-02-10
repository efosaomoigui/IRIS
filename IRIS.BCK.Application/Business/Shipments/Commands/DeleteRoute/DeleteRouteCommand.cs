using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteRoute
{
    public class DeleteRouteCommand : IRequest<DeleteRouteCommandResponse>
    {
        public int Id { get; set; }
    }
}