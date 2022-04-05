using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
    {
        public IInvoiceRepository _paymentRepository { get; set; }

        public UpdatePaymentCommandValidator(IInvoiceRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;

            RuleFor(p => p.PaymentMethod)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.Status)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.InvoiceCode)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
            {
            }
        }
    }
}