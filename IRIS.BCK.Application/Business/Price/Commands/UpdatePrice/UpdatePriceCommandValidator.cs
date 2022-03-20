using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.UpdatePrice
{
    public class UpdatePriceCommandValidator : AbstractValidator<UpdatePriceCommand>
    {
        public IPriceEntRepository _priceRepository { get; set; }

        public UpdatePriceCommandValidator(IPriceEntRepository priceRepository)
        {
            _priceRepository = priceRepository;

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.PricePerUnit)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.UnitWeight)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.RouteId)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
            {
            }
        }
    }
}