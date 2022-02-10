using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteRoute
{
    public class DeleteRouteCommandValidator : AbstractValidator<DeleteRouteCommand>
    {
        public IRouteRepository _routeRepository { get; set; }

        public DeleteRouteCommandValidator(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}