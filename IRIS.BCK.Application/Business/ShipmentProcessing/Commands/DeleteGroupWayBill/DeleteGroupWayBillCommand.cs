using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteGroupWayBill
{
    public class DeleteGroupWayBillCommand : IRequest<DeleteGroupWayBillCommandResponse>
    {
        public Guid Id { get; set; }
    }
}