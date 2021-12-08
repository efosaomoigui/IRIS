using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList
{
    public class GetShipmentListQuery : IRequest<List<ShipmentListViewModel>>
    {
    }
}
