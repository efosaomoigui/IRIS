using  IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Domain.Entities.AddressEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = IRIS.BCK.Core.Application.Business.Accounts.AccountEntities.User;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest<DeleteShipmentCommandResponse>
    {
        public Guid ShipmentId { get; set; }
    }
}