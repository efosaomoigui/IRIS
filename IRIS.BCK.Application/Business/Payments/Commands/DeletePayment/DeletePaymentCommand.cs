using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommand : IRequest<DeletePaymentCommandResponse>
    {
        public Guid Id { get; set; }
    }
}