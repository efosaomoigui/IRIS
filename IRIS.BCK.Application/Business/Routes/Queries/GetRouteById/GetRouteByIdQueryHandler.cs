using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Routes.Queries.GetRoutes;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Routes.Queries.GetOneRoute
{
    public class GetRouteByIdQueryHandler : IRequestHandler<GetRouteByIdQuery, List<RouteViewModel>>
    {
        private readonly IGenericRepository<Route> _routeRepository;
        private readonly IMapper _mapper;

        public GetRouteByIdQueryHandler(IGenericRepository<Route> routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }

        public Task<List<RouteViewModel>> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<RouteViewModel>> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        //{
        //    //var oneRoute = (await _routeRepository.GetByIdAsync()).Equals(x => x.);
        //    //return _mapper.Map<List<RouteViewModel>>(oneRoute);
        //  //  return (oneRoute);
        //}
    }
}