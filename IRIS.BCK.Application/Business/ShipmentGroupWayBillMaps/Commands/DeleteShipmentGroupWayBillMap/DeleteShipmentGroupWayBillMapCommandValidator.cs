using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentGroupWayBill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.DeleteShipmentGroupWayBillMap
{
    public class DeleteShipmentGroupWayBillMapCommandValidator : AbstractValidator<DeleteShipmentGroupWayBillMapCommand>
    {
        public IShipmentGroupWayBillMapRepository _shipmentGroupWayBillRepository { get; set; }

        public DeleteShipmentGroupWayBillMapCommandValidator(IShipmentGroupWayBillMapRepository shipmentGroupWayBillRepository)
        {
            _shipmentGroupWayBillRepository = shipmentGroupWayBillRepository;

            RuleFor(p => p.ShipmentGroupWayBillMapid)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}