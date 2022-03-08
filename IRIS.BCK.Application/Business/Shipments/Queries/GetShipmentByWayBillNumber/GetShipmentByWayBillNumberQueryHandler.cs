using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber
{
    public class GetShipmentByWayBillNumberQueryHandler : IRequestHandler<GetShipmentByWayBillNumberQuery, ShipmentViewModel>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentByWayBillNumberQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<ShipmentViewModel> Handle(GetShipmentByWayBillNumberQuery request, CancellationToken cancellationToken)
        {
            var waybillnumber = request.WayBill.ToString();
            var waybill = await _shipmentRepository.GetShipmentById(waybillnumber);

            return _mapper.Map<ShipmentViewModel>(waybill);
        }
    }
}