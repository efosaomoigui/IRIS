using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes
{
    public class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
    {
        public IRouteRepository _routeRepository { get; set; }

        public CreateRouteCommandValidator(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;

            RuleFor(p => p.AvailableAtTerminal)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.AvailableOnline)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.CaptainFee)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Departure)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Destination)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.DispatchFee)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.IsSubRoute)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.LoaderFee)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.MainRouteId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.RouteId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.RouteName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.RouteType)
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