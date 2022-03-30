using IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.CreateShipmentRequest;
using IRIS.BCK.Core.Domain.Entities.ShipmentRequestEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.ShipmentRequests
{
    public class ShipmentRequestMapsCommand
    {
        public static ShipmentRequest CreateShipmentRequestMapsCommand(CreateShipmentRequestCommand request)
        {
            return new ShipmentRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Customer = request.Customer,
                Email = request.Email,
                CustomerAddress = request.CustomerAddress,
                PhoneNumber = request.PhoneNumber
            };
        }
    }
}