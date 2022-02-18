using FluentValidation;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment
{
    internal class CreateShipmentCommandValidator : AbstractValidator<CreateShipmentCommand>
    {
        public IShipmentRepository _ShipmentRepository { get; set; }

        public CreateShipmentCommandValidator(IShipmentRepository shipmentRepository)
        {
            _ShipmentRepository = shipmentRepository;

            RuleFor(p => p.ShipmentItems)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Waybill) // Custom Validation for unique waybills
                .MustAsync(CheckUniqueWaybillNumber).WithMessage("{PropertyName} must be unique");

            RuleFor(p => p.Customer)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.GrandTotal)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.CustomerAddress)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.PickupOptions)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.Reciever)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.RecieverAddress)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }

        //implement custom error checks using methods here
        private Task<bool> CheckUniqueWaybillNumber(string waybill, CancellationToken arg2)
        {
            return _ShipmentRepository.CheckUniqueWaybillNumber(waybill);
        }
    }
}