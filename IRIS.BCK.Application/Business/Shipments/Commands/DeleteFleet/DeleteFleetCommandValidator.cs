using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteFleet
{
    public class DeleteFleetCommandValidator : AbstractValidator<DeleteFleetCommand>
    {
        public IFleetRepository _fleetRepository { get; set; }

        public DeleteFleetCommandValidator(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;

            RuleFor(p => p.FleetId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}