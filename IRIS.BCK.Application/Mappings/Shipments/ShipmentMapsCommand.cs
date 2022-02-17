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
                //AddressId = request.AddressId,
                breadth = request.breadth,
                Customer = request.Customer,
                CustomerAddress = request.CustomerAddress,
                DeclarationOfValueCheck = request.DeclarationOfValueCheck,
                DimensionUnit = request.DimensionUnit,
                Height = request.Height,
                IsdeclaredVal = request.IsdeclaredVal,
                IsWeightEstimated = request.IsWeightEstimated,
                ItemsWeight = request.ItemsWeight,
                length = request.length,
                PickupOptions = request.PickupOptions,
                Reciever = request.Reciever,
                RecieverAddress = request.RecieverAddress,
                ShipmentItems = request.ShipmentItems,
                Waybill = request.Waybill
            };
        }
    }
}