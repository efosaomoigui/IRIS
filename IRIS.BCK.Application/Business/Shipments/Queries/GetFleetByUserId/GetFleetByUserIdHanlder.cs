using AutoMapper;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetById;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetByUserId
{
    public class GetFleetByUserIdHanlder : IRequestHandler<GetFleetByUserIdQuery, FleetViewModel>
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IMapper _mapper;

        public GetFleetByUserIdHanlder(IFleetRepository fleetRepository, IMapper mapper)
        {
            _fleetRepository = fleetRepository;
            _mapper = mapper;
        }

        public async Task<FleetViewModel> Handle(GetFleetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userid = request.UserId.ToString();
            var user = await _fleetRepository.GetFleetByUserId(userid);

            return _mapper.Map<FleetViewModel>(user);
        }
    }
}