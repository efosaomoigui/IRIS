using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ShipmentRequestEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Queries.GetShipmentRequest
{
    public class GetShipmentRequestQueryHandler : IRequestHandler<GetShipmentRequestQuery, List<ShipmentRequestListViewModel>>
    {
        private readonly IGenericRepository<ShipmentRequest> _shipmentRequestRepository;
        private readonly IMapper _mapper;

        public GetShipmentRequestQueryHandler(IGenericRepository<ShipmentRequest> shipmentRequestRepository, IMapper mapper)
        {
            _shipmentRequestRepository = shipmentRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<ShipmentRequestListViewModel>> Handle(GetShipmentRequestQuery request, CancellationToken cancellationToken)
        {
            var allShimentRequest = (await _shipmentRequestRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<ShipmentRequestListViewModel>>(allShimentRequest);
        }
    }
}