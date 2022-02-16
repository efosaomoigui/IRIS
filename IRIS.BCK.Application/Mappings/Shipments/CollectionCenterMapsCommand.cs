using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter;
using IRIS.BCK.Core.Domain.Entities.ShipmentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Shipments
{
    public class CollectionCenterMapsCommand
    {
        public static CollectionCenter CreateCollectionCenterMapsCommand(CreateCollectionCenterCommand request)
        {
            return new CollectionCenter
            {
                Shipment = request.Shipment,
                CollectionStatus = request.CollectionStatus,
                ShipmentId = request.ShipmentId,
                UserId = request.UserId
            };
        }
    }
}