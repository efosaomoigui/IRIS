using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Shipments
{
    public class ShipmentMapsCommand
    {
        public static Shipment CreateShipmentMapsCommand(CreateShipmentCommand request)
        {
            return new Shipment
            {
                AddressId = request.AddressId,
                //AddressId = request.AddressId,
                PickupOptions = request.PickupOptions,
                Reciever = request.Reciever,
                RecieverAddress = request.RecieverAddress,
                ShipmentItems = request.ShipmentItems,
                Waybill = request.Waybill,
                GrandTotal = request.GrandTotal
            };
        }
    }
}