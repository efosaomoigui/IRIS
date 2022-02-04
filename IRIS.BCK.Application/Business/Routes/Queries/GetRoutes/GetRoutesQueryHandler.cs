using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Routes.Queries.GetRoutes
{
    public class GetRouteQueryHandler : IRequestHandler<GetRouteQuery, List<RouteViewModel>>
    {
        private readonly IGenericRepository<Route> _routeRepository;
        private readonly IMapper _mapper;

        public GetRouteQueryHandler(IGenericRepository<Route> routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public async Task<List<RouteViewModel>> Handle(GetRouteQuery request, CancellationToken cancellationToken)
        {
            var allRoutes = (await _routeRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<RouteViewModel>>(allRoutes);
        }
    }
}