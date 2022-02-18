using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateGroupWayBill
{
    public class UpdateGroupWayBillCommandValidator : AbstractValidator<UpdateGroupWayBillCommand>
    {
        public IGroupWayBillRepository _groupWayBillRepository { get; set; }

        public UpdateGroupWayBillCommandValidator(IGroupWayBillRepository groupWayBillRepository)
        {
            _groupWayBillRepository = groupWayBillRepository;

            RuleFor(p => p.GroupCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.Shipment)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.ShipmentId)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
        }
    }
}