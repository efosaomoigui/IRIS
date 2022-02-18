using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteGroupWayBill
{
    public class DeleteGroupWayBillCommandValidator : AbstractValidator<DeleteGroupWayBillCommand>
    {
        public IGroupWayBillRepository _groupWayBillRepository { get; set; }

        public DeleteGroupWayBillCommandValidator(IGroupWayBillRepository groupWayBillRepository)
        {
            _groupWayBillRepository = groupWayBillRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}