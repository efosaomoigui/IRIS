﻿using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateRoute
{
    public class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommand>
    {
        public IRouteRepository _routeRepository { get; set; }

        public UpdateRouteCommandValidator(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;

            RuleFor(p => p.Departure)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Destination)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.RouteName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }

        //implement custom error checks using methods here
        private Task<bool> CheckUniqueWaybillNumber(string route, CancellationToken arg2)
        {
            return _routeRepository.CheckRouteNumber(route);
        }
    }
}