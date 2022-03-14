using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips
{
    public class CreateTripCommandValidator : AbstractValidator<CreateTripCommand>
    {
        public ITripRepository _tripRepository { get; set; }

        public CreateTripCommandValidator(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;

            //RuleFor(p => p.Dispatcher)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull();

            //RuleFor(p => p.Driver)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull();

            RuleFor(p => p.Fleet)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.RouteCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.TripReference)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}