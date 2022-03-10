using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetManifestByManifestCodeQueryHandler(IManifestRepository manifestRepository, IMapper mapper)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
        }

        public async Task<ManifestViewModel> Handle(GetManifestByManifestCodeQuery request, CancellationToken cancellationToken)
        {
            var manifestcode = request.ManifestCode.ToString();
            var manifest = await _manifestRepository.GetManifestByManifestCode(manifestcode);

            return _mapper.Map<ManifestViewModel>(manifest);
        }
    }
}