using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter
{
    public class CreateCollectionCenterCommandValidator : AbstractValidator<CreateCollectionCenterCommand>
    {
        public ICollectionCenterRepository _collectionCenterRepository { get; set; }

        public CreateCollectionCenterCommandValidator(ICollectionCenterRepository collectionCenterRepository)
        {
            _collectionCenterRepository = collectionCenterRepository;

            RuleFor(p => p.CollectionStatus)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Shipment)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            {
            }
        }
    }
}