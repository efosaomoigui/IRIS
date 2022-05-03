using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes
{
    public class GetRouteQueryHandler : IRequestHandler<GetRouteQuery, List<RouteViewModel>>
    {
        private readonly IGenericRepository<Route> _routeRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetRouteQueryHandler(IGenericRepository<Route> routeRepository, IMapper mapper, IShipmentRepository shipmentRepository = null)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<List<RouteViewModel>> Handle(GetRouteQuery request, CancellationToken cancellationToken)
        {
            var allRoutes = (await _routeRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<RouteViewModel>>(allRoutes);
        }
    }

    public class GetRouteForGroupWaybillQueryHandler : IRequestHandler<GetRouteForGroupWaybillQuery, List<RouteViewModel>> 
    {
        private readonly IGenericRepository<Route> _routeRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetRouteForGroupWaybillQueryHandler(IGenericRepository<Route> routeRepository, IMapper mapper, IShipmentRepository shipmentRepository = null)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<List<RouteViewModel>> Handle(GetRouteForGroupWaybillQuery request, CancellationToken cancellationToken)
        {
            var unProcessedShipmentShipments = await _shipmentRepository.GetUnprocessedShipment();
            var arrUnprocessedShipmentsRoutes = unProcessedShipmentShipments.ToArray();
            var allRoutes = (await _routeRepository.GetAllAsync()).Where(t => arrUnprocessedShipmentsRoutes.Contains(t.RouteId)).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<RouteViewModel>>(allRoutes);
        }
    }

    public class GetRouteForGroupWaybillQuery : IRequest<List<RouteViewModel>>
    {
    }

    public class GetRouteForManifestQueryHandler : IRequestHandler<GetRouteForManifestQuery, List<RouteViewModel>>
    {
        private readonly IGenericRepository<Route> _routeRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IGroupWayBillRepository _groupWaybillRepository; 
        private readonly IMapper _mapper;

        public GetRouteForManifestQueryHandler(IGenericRepository<Route> routeRepository, IMapper mapper, IShipmentRepository shipmentRepository = null, IGroupWayBillRepository groupWaybillRepository = null)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
            _groupWaybillRepository = groupWaybillRepository;
        }

        public async Task<List<RouteViewModel>> Handle(GetRouteForManifestQuery request, CancellationToken cancellationToken)
        {
            var unProcessedGroups = await _groupWaybillRepository.GetUnprocessedGroupwaybillTRoute(); 
            var arrUnprocessedGroupRoutes = unProcessedGroups.ToArray();
            var allRoutes = (await _routeRepository.GetAllAsync()).Where(t => arrUnprocessedGroupRoutes.Contains(t.RouteId)).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<RouteViewModel>>(allRoutes); 
        }
    }

    public class GetRouteForManifestQuery : IRequest<List<RouteViewModel>>
    {
    }
}