using FluentValidation;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommandValidator : AbstractValidator<DeleteShipmentCommand>
    {
        public IShipmentRepository _ShipmentRepository { get; set; }

        public DeleteShipmentCommandValidator(IShipmentRepository shipmentRepository)
        {
            _ShipmentRepository = shipmentRepository;

            RuleFor(p => p.ShipmentId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}