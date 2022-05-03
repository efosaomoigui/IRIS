using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Fleets.Queries.GetFleets
{
    public class GetFleetQueryHandler : IRequestHandler<GetFleetQuery, List<FleetListViewModel>>
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IMapper _mapper;

        public GetFleetQueryHandler(IFleetRepository fleetRepository, IMapper mapper)
        {
            _fleetRepository = fleetRepository;
            _mapper = mapper;
        }

        public async Task<List<FleetListViewModel>> Handle(GetFleetQuery request, CancellationToken cancellationToken)
        {
            var allFleet = await _fleetRepository.GetFleetWithOwner();
            //return _mapper.Map<List<FleetListViewModel>>(allFleet);
            return allFleet;
        }
    }
}