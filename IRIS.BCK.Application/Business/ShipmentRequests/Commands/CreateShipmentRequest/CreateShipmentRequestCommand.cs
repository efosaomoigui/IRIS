using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.CreateShipmentRequest
{
    public class CreateShipmentRequestCommand : IRequest<CreateShipmentRequestCommandResponse>
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

        public string CustomerAddress { get; set; }

        //Receivers Information
        public Guid Reciever { get; set; }

        public string RecieverAddress { get; set; }

        //PickUp Options
        public string PickupOptions { get; set; }

        public Guid ServiceCenterId { get; set; }
    }
}