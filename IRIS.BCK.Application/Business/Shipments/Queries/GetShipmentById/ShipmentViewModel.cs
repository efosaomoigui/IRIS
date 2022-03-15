using  IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById
{
    public class ShipmentViewModel
    {
        public Guid ShipmentId { get; set; }

        public string Waybill { get; set; }

        public Guid Customer { get; set; }

        public decimal GrandTotal { get; set; }

        public ICollection<Address> CustomerAddress { get; set; }

        public Guid Reciever { get; set; }

        public ICollection<Address> RecieverAddress { get; set; }

        public PickupOptions PickupOptions { get; set; }

        public List<ShipmentItem> ShipmentItems { get; set; }

        public Guid ServiceCenterId { get; set; }
    }
}