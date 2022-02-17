using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteManifest
{
    public class DeleteManifestCommandValidator : AbstractValidator<DeleteManifestCommand>
    {
        public IManifestRepository _manifestRepository { get; set; }

        public DeleteManifestCommandValidator(IManifestRepository manifestRepository)
        {
            _manifestRepository = manifestRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}