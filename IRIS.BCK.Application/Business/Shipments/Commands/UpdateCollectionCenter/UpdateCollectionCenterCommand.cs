using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateCollectionCenter
{
    public class UpdateCollectionCenterCommand : IRequest<UpdateCollectionCenterCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }

        public Shipment Shipment { get; set; }
        public CollectionCenterEnum CollectionStatus { get; set; }
        public Guid UserId { get; set; }
    }
}