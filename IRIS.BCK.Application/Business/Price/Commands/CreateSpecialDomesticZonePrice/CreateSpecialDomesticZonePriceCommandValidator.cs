using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.SpecialDomesticZonePrice
{
    public class CreateSpecialDomesticZonePriceCommandValidator : AbstractValidator<CreateSpecialDomesticZonePriceCommand>
    {
        public ISpecialDomesticZonePriceRepository _specialDomesticZonePriceRepository { get; set; }

        public CreateSpecialDomesticZonePriceCommandValidator(ISpecialDomesticZonePriceRepository specialDomesticZonePriceRepository)
        {
            _specialDomesticZonePriceRepository = specialDomesticZonePriceRepository;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.PriceId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.SpecialDomesticPackage)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.SpecialDomesticPackageId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Weight)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Zone)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.ZoneId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}