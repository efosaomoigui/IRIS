using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest
{
    public class GetManifestQueryHandler : IRequestHandler<GetManifestQuery, List<ManifestListViewModel>>
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly IMapper _mapper;

        public GetManifestQueryHandler(IManifestRepository manifestRepository, IMapper mapper)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
        }

        public async Task<List<ManifestListViewModel>> Handle(GetManifestQuery request, CancellationToken cancellationToken)
        {
            var allManifest = await _manifestRepository.GetManifestGroupWaybillByRouteId();
            return _mapper.Map<List<ManifestListViewModel>>(allManifest);
        }
    }
}