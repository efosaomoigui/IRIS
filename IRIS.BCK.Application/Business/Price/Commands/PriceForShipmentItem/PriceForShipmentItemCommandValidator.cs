using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem
{
    public class PriceForShipmentItemCommandValidator : AbstractValidator<PriceForShipmentItemCommand>
    {
        public IPriceEntRepository _priceRepository { get; set; }

        public PriceForShipmentItemCommandValidator(IPriceEntRepository priceRepository) 
        {
            _priceRepository = priceRepository;

            RuleFor(p => p.Weight)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.Length)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.Breadth)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();        
            
            RuleFor(p => p.Height)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
        }
    }
}