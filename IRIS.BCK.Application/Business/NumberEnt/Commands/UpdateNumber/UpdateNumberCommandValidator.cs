using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.UpdateNumber
{
    public class UpdateNumberCommandValidator : AbstractValidator<UpdateNumberCommand>
    {
        public IPaymentRepository _paymentRepository { get; set; }

        public UpdateNumberCommandValidator(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;

            RuleFor(p => p.ServiceCentreCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            {
            }
        }
    }
}