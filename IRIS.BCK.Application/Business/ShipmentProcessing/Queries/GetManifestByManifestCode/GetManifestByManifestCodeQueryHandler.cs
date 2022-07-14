using AutoMapper;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByManifestCode
{
    public class GetManifestByManifestCodeQueryHandler : IRequestHandler<GetManifestByManifestCodeQuery, ManifestViewModel>
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly IGroupWayBillRepository _groupRepository; 
        private readonly IRouteRepository _routeRepository; 
        private readonly IMapper _mapper;

        public GetManifestByManifestCodeQueryHandler(IManifestRepository manifestRepository, IMapper mapper, IRouteRepository routeRepository = null, IGroupWayBillRepository groupRepository = null)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
            _routeRepository = routeRepository;
            _groupRepository = groupRepository;
        }

        public async Task<ManifestViewModel> Handle(GetManifestByManifestCodeQuery request, CancellationToken cancellationToken)
        {
            var manifestcode = request.ManifestCode.ToString();
            var manifest = await _manifestRepository.GetManifestByManifestCode(manifestcode);
            var result = new ManifestViewModel();
            result.ManifestCode = manifest[0].ManifestCode;

            foreach (var item in manifest)
            {
                var route = await _routeRepository.GetRouteById(item.RouteId.ToString());

                result.GroupWaybills.Add(new ManifestDto
                {
                    ManifestCode = item.ManifestCode,
                    GroupWayBillCode = item.GroupWayBillCode,
                    Departure = route.Departure,
                    Destination = route.Destination,
                    CreatedDate = item.CreatedDate
                });
            }

            return result;
        }
    }
}