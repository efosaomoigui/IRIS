using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentGroupWayBill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.UpdateShipmentGroupWayBillMap
{
    public class UpdateShipmentGroupWayBillMapCommandValidator : AbstractValidator<UpdateShipmentGroupWayBillMapCommand>
    {
        public IShipmentGroupWayBillMapRepository _shipmentGroupWayBillRepository { get; set; }

        public UpdateShipmentGroupWayBillMapCommandValidator(IShipmentGroupWayBillMapRepository shipmentGroupWayBillRepository)
        {
            _shipmentGroupWayBillRepository = shipmentGroupWayBillRepository;

            RuleFor(p => p.GroupWayBillCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.ShipmentWaybill)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            {
            }
        }
    }
}