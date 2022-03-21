using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePaymentLog
{
    public class CreatePaymentLogCommandValidator : AbstractValidator<CreatePaymentLogCommand>
    {
        public IPaymentLogRepository _paymentLogRepository { get; set; }

        public CreatePaymentLogCommandValidator(IPaymentLogRepository paymentLogRepository)
        {
            _paymentLogRepository = paymentLogRepository;

            RuleFor(p => p.PaymentMethod)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.TransactionCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}