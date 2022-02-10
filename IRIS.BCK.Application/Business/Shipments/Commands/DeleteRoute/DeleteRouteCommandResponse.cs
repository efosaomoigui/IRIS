using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteRoute
{
    public class DeleteRouteCommandResponse : BaseResponse
    {
        public DeleteRouteCommandResponse() : base()
        {
        }

        public RouteDto Routedto { get; set; }
    }
}