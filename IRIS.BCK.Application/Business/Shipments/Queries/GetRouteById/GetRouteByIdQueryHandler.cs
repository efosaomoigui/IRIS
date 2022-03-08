using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetOneRoute
{
    public class GetRouteByIdQueryHandler : IRequestHandler<GetRouteByIdQuery, RouteViewModel>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public GetRouteByIdQueryHandler(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<RouteViewModel> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var routeid = request.RouteId.ToString();
            var route = await _routeRepository.GetRouteById(routeid);

            return _mapper.Map<RouteViewModel>(route);
        }
    }
}