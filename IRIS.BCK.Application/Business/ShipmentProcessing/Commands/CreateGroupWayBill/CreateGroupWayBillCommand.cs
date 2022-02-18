using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill
{
    public class CreateGroupWayBillCommand : IRequest<CreateGroupWayBillCommandResponse>
    {
        public Guid Id { get; set; }
        public string GroupCode { get; set; }

        public Guid ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        // public User UserId { get; set; }
    }
}