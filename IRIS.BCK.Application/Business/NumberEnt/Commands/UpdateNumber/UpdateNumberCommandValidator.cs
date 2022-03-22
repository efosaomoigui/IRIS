using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
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
        private readonly INumberEntRepository _numberEntRepository;

        public UpdateNumberCommandValidator(INumberEntRepository numberEntRepository)
        {
            _numberEntRepository = numberEntRepository;

            RuleFor(p => p.ServiceCentreCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            {
            }
        }
    }
}