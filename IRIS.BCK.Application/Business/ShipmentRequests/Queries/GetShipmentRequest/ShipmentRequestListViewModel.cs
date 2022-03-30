using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Queries.GetShipmentRequest
{
    public class ShipmentRequestListViewModel
    {
        public Guid ShipmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Waybill { get; set; }

        //Customer Information
        public Guid Customer { get; set; }

        public double GrandTotal { get; set; }

        public ICollection<Address> CustomerAddress { get; set; }

        //Receivers Information
        public Guid Reciever { get; set; }

        public ICollection<Address> RecieverAddress { get; set; }

        //PickUp Options
        public PickupOptions PickupOptions { get; set; }

        public Guid ServiceCenterId { get; set; }
    }
}