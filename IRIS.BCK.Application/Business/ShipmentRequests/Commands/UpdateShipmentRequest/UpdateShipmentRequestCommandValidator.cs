using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRequestRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.UpdateShipmentRequest
{
    public class UpdateShipmentRequestCommandValidator : AbstractValidator<UpdateShipmentRequestCommand>
    {
        public IShipmentRequestRepository _shipmentRequestRepository { get; set; }

        public UpdateShipmentRequestCommandValidator(IShipmentRequestRepository shipmentRequestRepository)
        {
            _shipmentRequestRepository = shipmentRequestRepository;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}