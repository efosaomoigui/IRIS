using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateGroupWayBill
{
    public class UpdateGroupWayBillCommand : IRequest<UpdateGroupWayBillCommandResponse>
    {
        public Guid Id { get; set; }
        public string GroupCode { get; set; }
        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}