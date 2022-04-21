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
    public class GetShipmentByRouteIdQueryHandler : IRequestHandler<GetShipmentByRouteIdQuery, List<ShipmentRouteViewModel>> 
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentByRouteIdQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<List<ShipmentRouteViewModel>> Handle(GetShipmentByRouteIdQuery request, CancellationToken cancellationToken)
        {
            var routeid = request.RouteId.ToString();
            var shipment = await _shipmentRepository.GetShipmentByRouteId(routeid); 

            return _mapper.Map<List<ShipmentRouteViewModel>>(shipment);
        }
    }
}