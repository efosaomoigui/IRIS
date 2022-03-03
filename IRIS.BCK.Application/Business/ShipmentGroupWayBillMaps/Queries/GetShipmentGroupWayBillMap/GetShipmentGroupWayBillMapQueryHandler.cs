using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ShipmentGroupWayBillMapEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Queries.GetShipmentGroupWayBillMap
{
    public class GetShipmentGroupWayBillMapQueryHandler : IRequestHandler<GetShipmentGroupWayBillMapQuery, List<ShipmentGroupWayBillMapListViewModel>>
    {
        private readonly IGenericRepository<ShipmentGroupWayBillMap> _shipmentGroupRepository;
        private readonly IMapper _mapper;

        public GetShipmentGroupWayBillMapQueryHandler(IGenericRepository<ShipmentGroupWayBillMap> shipmentGroupRepository, IMapper mapper)
        {
            _shipmentGroupRepository = shipmentGroupRepository;
            _mapper = mapper;
        }

        public async Task<List<ShipmentGroupWayBillMapListViewModel>> Handle(GetShipmentGroupWayBillMapQuery request, CancellationToken cancellationToken)
        {
            var allShipmentGroup = (await _shipmentGroupRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<ShipmentGroupWayBillMapListViewModel>>(allShipmentGroup);
        }
    }
}