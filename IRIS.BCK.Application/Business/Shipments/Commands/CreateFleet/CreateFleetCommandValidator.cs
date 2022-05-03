﻿using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets
{
    public class CreateFleetCommandValidator : AbstractValidator<CreateFleetCommand>
    {
        public IFleetRepository _fleetRepository { get; set; }

        public CreateFleetCommandValidator(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;

            RuleFor(p => p.Capacity)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.ChassisNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            //RuleFor(p => p.FleetId)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull();

            RuleFor(p => p.FleetMake)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.FleetModel)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.FleetType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}