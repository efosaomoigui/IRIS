using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateCollectionCenter
{
    public class UpdateCollectionCenterCommandValidator : AbstractValidator<UpdateCollectionCenterCommand>
    {
        public ICollectionCenterRepository _collectionCenterRepository { get; set; }

        public UpdateCollectionCenterCommandValidator(ICollectionCenterRepository collectionCenterRepository)
        {
            _collectionCenterRepository = collectionCenterRepository;

            RuleFor(p => p.CollectionStatus)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            {
            }
        }
    }
}