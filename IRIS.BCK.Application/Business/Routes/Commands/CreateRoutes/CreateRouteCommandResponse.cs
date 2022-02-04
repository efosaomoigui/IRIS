using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Routes.Commands.CreateRoutes
{
    public class CreateRouteCommandResponse : BaseResponse
    {
        public CreateRouteCommandResponse() : base()
        {
        }

        public RouteDto Routedto { get; set; }
    }
}