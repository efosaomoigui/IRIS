using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateManifest
{
    public class UpdateManifestCommandValidator : AbstractValidator<UpdateManifestCommand>
    {
        public IManifestRepository _manifestRepository { get; set; }

        public UpdateManifestCommandValidator(IManifestRepository manifestRepository)
        {
            _manifestRepository = manifestRepository;

            RuleFor(p => p.GroupWayBill)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.ManifestCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.GroupWayBillId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}