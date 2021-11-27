using FluentValidation;
using IRIS.BCK.Application.Interfaces.Pesistence.IShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment
{
    class CreateShipmentCommandValidator : AbstractValidator<CreateShipmentCommand>
    {
        public IShipmentRepository _ShipmentRepository { get; set; }
        public CreateShipmentCommandValidator(IShipmentRepository shipmentRepository)
        {
            _ShipmentRepository = shipmentRepository;

            RuleFor(p => p.waybill)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.waybill) // Custom Validation for unique waybills
                .MustAsync(CheckUniqueWaybillNumber).WithMessage("{PropertyName} must be unique");
        }

        //implement custom error checks using methods here
        private Task<bool> CheckUniqueWaybillNumber(string waybill, CancellationToken arg2)
        {
            return _ShipmentRepository.CheckUniqueWaybillNumber(waybill);
        }

    }
}
