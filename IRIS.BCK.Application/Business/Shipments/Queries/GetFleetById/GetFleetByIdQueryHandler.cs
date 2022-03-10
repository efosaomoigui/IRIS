using AutoMapper;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetById
{
    public class GetFleetByIdQueryHandler : IRequestHandler<GetFleetByIdQuery, FleetViewModel>
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IMapper _mapper;

        public GetFleetByIdQueryHandler(IFleetRepository fleetRepository, IMapper mapper)
        {
            _fleetRepository = fleetRepository;
            _mapper = mapper;
        }

        public async Task<FleetViewModel> Handle(GetFleetByIdQuery request, CancellationToken cancellationToken)
        {
            var fleetid = request.FleetId.ToString();
            var fleet = await _fleetRepository.GetFleetById(fleetid);

            return _mapper.Map<FleetViewModel>(fleet);
        }
    }
}