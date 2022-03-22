using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreateNumberEnt 
{
    public class CreateNumberCommandValidator : AbstractValidator<CreateNumberCommand>
    {
        public INumberEntRepository _numberEntRepository { get; set; } 

        public CreateNumberCommandValidator(INumberEntRepository numberRepository)
        {
            _numberEntRepository = numberRepository;

            RuleFor(p => p.NumberCode)
                .NotEmpty().WithMessage("{PropertyName} is required") 
                .NotNull();

        }
    }
}