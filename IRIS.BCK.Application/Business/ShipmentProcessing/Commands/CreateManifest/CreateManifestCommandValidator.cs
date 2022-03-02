using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateManifest
{
    public class CreateManifestCommandValidator : AbstractValidator<CreateManifestCommand>
    {
        public IManifestRepository _manifestRepository { get; set; }

        public CreateManifestCommandValidator(IManifestRepository manifestRepository)
        {
            _manifestRepository = manifestRepository;

            RuleFor(p => p.ManifestCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}