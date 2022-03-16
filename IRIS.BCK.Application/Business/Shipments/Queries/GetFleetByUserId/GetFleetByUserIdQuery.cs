using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetByUserId
{
    public class GetFleetByUserIdQuery : IRequest<FleetViewModel>
    {
        public Guid UserId { get; set; }

        public GetFleetByUserIdQuery(string userid)
        {
            Guid UserGuid = new Guid(userid);
            UserId = UserGuid;
        }
    }
}