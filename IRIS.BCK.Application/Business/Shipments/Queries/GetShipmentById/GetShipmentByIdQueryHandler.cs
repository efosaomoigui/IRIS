using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById
{
    public class GetShipmentByIdQueryHandler : IRequestHandler<GetShipmentByIdQuery, ShipmentViewModel>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentByIdQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<ShipmentViewModel> Handle(GetShipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var shipmentid = request.ShipmentId.ToString();
            var shipment = await _shipmentRepository.GetShipmentById(shipmentid);

            return _mapper.Map<ShipmentViewModel>(shipment);
        }
    }
}