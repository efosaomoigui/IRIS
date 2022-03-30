using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Queries.GetShipmentRequest
{
    public class GetShipmentRequestQuery : IRequest<List<ShipmentRequestListViewModel>>
    {
    }
}