using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateRoute
{
    public class UpdateRouteCommandResponse : BaseResponse
    {
        public UpdateRouteCommandResponse() : base()
        {
        }

        public RouteDto Routedto { get; set; }
    }
}