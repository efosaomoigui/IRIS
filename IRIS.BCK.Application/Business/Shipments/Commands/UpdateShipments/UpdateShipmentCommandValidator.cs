using FluentValidation;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateShipments
{
    public class UpdateShipmentCommandValidator : AbstractValidator<UpdateShipmentCommand>
    {
        public IShipmentRepository _ShipmentRepository { get; set; }

        public UpdateShipmentCommandValidator(IShipmentRepository shipmentRepository)
        {
            _ShipmentRepository = shipmentRepository;

            RuleFor(p => p.Customer)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.GrandTotal)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
            {
            }
        }
    }
}