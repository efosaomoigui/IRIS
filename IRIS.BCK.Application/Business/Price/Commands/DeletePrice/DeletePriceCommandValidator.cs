using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.DeletePrice
{
    public class DeletePriceCommandValidator : AbstractValidator<DeletePriceCommand>
    {
        public IPriceEntRepository _priceRepository { get; set; }

        public DeletePriceCommandValidator(IPriceEntRepository priceRepository)
        {
            _priceRepository = priceRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            {
            }
        }
    }
}