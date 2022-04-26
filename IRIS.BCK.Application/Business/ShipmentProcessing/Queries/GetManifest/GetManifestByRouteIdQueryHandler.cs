using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill
{
    public class GetManifestByRouteIdQueryHandler : IRequestHandler<GetManifestByRouteIdQuery, List<ManifestListViewModel>>
    {
        private readonly IManifestRepository _manifestRepository; 
        private readonly IMapper _mapper;

        public GetManifestByRouteIdQueryHandler(IMapper mapper, IManifestRepository manifestRepository = null)
        {
            _mapper = mapper;
            _manifestRepository = manifestRepository;
        }

        public async Task<List<ManifestListViewModel>> Handle(GetManifestByRouteIdQuery request, CancellationToken cancellationToken)
        {
            var allGroup =  await _manifestRepository.GetManifestByRouteId(request.RouteId.ToString());
            return allGroup;
        }
    }
}