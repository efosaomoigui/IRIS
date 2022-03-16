using IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceByRouteId
{
    public class GetPriceByRouteIdQuery : IRequest<PriceViewModel>
    {
        public Guid RouteId { get; set; }

        public GetPriceByRouteIdQuery(string routeid)
        {
            Guid RouteGuid = new Guid(routeid);
            RouteId = RouteGuid;
        }
    }
}