using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommandValidator : AbstractValidator<DeletePaymentCommand>
    {
        public IPaymentRepository _paymentRepository { get; set; }

        public DeletePaymentCommandValidator(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}