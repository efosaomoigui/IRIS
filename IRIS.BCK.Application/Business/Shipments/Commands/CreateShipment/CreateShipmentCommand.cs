using  IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment
{
    public class CreateShipmentCommand : IRequest<CreateShipmentCommandResponse>
    {
        public int ShipmentId { get; set; }
        public string Waybill { get; set; }

        //Customer Information
        public Guid Customer { get; set; }

        //[ForeignKey]
        public Guid AddressId { get; set; }

        public double GrandTotal { get; set; }
        //public Address CustomerAddress { get; set; }

        public List<Address> CustomerAddress { get; set; }

        //Receivers Information
        public Guid Reciever { get; set; }

        public List<Address> RecieverAddress { get; set; }

        //PickUp Options
        public PickupOptions PickupOptions { get; set; }

        //Shipment Items && pricing
        public List<ShipmentItem> ShipmentItems { get; set; }
    }
}