using FluentValidation;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateTrips;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteTrips
{
    public class DeleteTripCommandValidator : AbstractValidator<DeleteTripCommand>
    {
        public ITripRepository _tripRepository { get; set; }

        public DeleteTripCommandValidator(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}