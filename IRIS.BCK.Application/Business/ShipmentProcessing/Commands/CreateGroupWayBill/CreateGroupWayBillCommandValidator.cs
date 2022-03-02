using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill
{
    public class CreateGroupWayBillCommandValidator : AbstractValidator<CreateGroupWayBillCommand>
    {
        public IGroupWayBillRepository _groupWayBillRepository { get; set; }

        public CreateGroupWayBillCommandValidator(IGroupWayBillRepository groupWayBillRepository)
        {
            _groupWayBillRepository = groupWayBillRepository;

            RuleFor(p => p.GroupCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}