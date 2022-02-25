using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter
{
    public class CreateCollectionCenterCommand : IRequest<CreateCollectionCenterCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }
        public CollectionCenterEnum CollectionStatus { get; set; }
        public Guid UserId { get; set; }
    }
}