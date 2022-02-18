using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill
{
    public class GetGroupWayBillQuery : IRequest<List<GroupWayBillListViewModel>>
    {
    }
}