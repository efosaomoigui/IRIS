using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteCollectionCenter
{
    public class DeleteCollectionCenterCommandValidator : AbstractValidator<DeleteCollectionCenterCommand>
    {
        public ICollectionCenterRepository _collectionCenterRepository { get; set; }

        public DeleteCollectionCenterCommandValidator(ICollectionCenterRepository collectionCenterRepository)
        {
            _collectionCenterRepository = collectionCenterRepository;

            RuleFor(p => p.ShipmentId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            {
            }
        }
    }
}