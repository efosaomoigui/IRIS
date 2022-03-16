using  IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList
{
    public class ShipmentListViewModel
    {
        public Guid ShipmentId { get; set; }

        public string Waybill { get; set; }

        //Customer Information
        public Guid Customer { get; set; }

        public decimal GrandTotal { get; set; }

        public ICollection<Address> CustomerAddress { get; set; }

        //Receivers Information
        public Guid Reciever { get; set; }

        public ICollection<Address> RecieverAddress { get; set; }

        //PickUp Options
        public PickupOptions PickupOptions { get; set; }

        //Shipment Items && pricing
        public List<ShipmentItem> ShipmentItems { get; set; }

        public Guid ServiceCenterId { get; set; }
    }
}