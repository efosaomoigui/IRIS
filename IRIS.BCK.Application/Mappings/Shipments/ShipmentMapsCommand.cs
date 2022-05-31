using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
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
                PickupOptions = request.PickupOptions,
                Customer = request.Customer,
                //CustomerAddress = request.CustomerAddress,
                Reciever = request.Reciever,
                //RecieverAddress = request.RecieverAddress,
                ShipmentItems = request.ShipmentItems,
                Waybill = request.Waybill,
                GrandTotal = request.GrandTotal
            };
        }

        public static Shipment CreateShipmentValuesMapsCommand(PaymentCriteriaCommand request) 
        {
            return new Shipment
            {
                //PickupOptions = PickupOptions.ServiceCenter,
                //AddressId = request.AddressId,
                Customer = (Guid)request.UserId,
                //CustomerAddress = request.CustomerAddress,
                Reciever = (Guid)request.Reciever,
                //RecieverAddress = request.RecieverAddress,
                Waybill = request.WaybillNumber,
                GrandTotal = request.Amount,
                //ShipmentItems = null,
            };
        }        
        
        public static Shipment CreateShipmentValuesMapsCommand2(RegisterShipmentCommand request) 
        {
            return new Shipment
            {
                //PickupOptions = PickupOptions.ServiceCenter,
                //AddressId = request.AddressId,
                Customer = (Guid)request.UserId,
                //CustomerAddress = request.CustomerAddress,
                Reciever = (Guid)request.Reciever,
                //RecieverAddress = request.RecieverAddress,
                Waybill = request.WaybillNumber,
                GrandTotal = request.Amount,
                //ShipmentItems = null,
            };
        }
    }
}