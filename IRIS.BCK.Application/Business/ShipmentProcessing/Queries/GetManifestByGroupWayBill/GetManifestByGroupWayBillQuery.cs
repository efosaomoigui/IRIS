using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByManifestCode;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByGroupWayBill
{
    public class GetManifestByGroupWayBillQuery : IRequest<ManifestViewModel>
    {
        public Guid GroupWayBillId { get; set; }

        public GetManifestByGroupWayBillQuery(string waybill)
        {
            Guid GroupWayBill = new Guid(waybill);
            GroupWayBillId = GroupWayBill;
        }
    }
}