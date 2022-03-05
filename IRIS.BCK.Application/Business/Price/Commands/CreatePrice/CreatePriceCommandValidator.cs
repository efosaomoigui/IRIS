using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice
{
    public class CreatePriceCommandValidator : AbstractValidator<CreatePriceCommand>
    {
        public IPriceEntRepository _priceRepository { get; set; }

        public CreatePriceCommandValidator(IPriceEntRepository priceRepository)
        {
            _priceRepository = priceRepository;

            //RuleFor(p => p.Category)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull();

            RuleFor(p => p.PricePerUnit)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.Route)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.UnitWeight)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
        }
    }
}