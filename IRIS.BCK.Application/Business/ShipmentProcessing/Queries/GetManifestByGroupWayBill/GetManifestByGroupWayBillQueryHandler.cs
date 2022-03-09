using AutoMapper;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByManifestCode;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByGroupWayBill
{
    public class GetManifestByGroupWayBillQueryHandler : IRequestHandler<GetManifestByGroupWayBillQuery, ManifestViewModel>
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly IMapper _mapper;

        public GetManifestByGroupWayBillQueryHandler(IManifestRepository manifestRepository, IMapper mapper)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
        }

        public async Task<ManifestViewModel> Handle(GetManifestByGroupWayBillQuery request, CancellationToken cancellationToken)
        {
            var waybillid = request.GroupWayBillId.ToString();
            var waybill = await _manifestRepository.GetManifestByWayBill(waybillid);

            return _mapper.Map<ManifestViewModel>(waybill);
        }
    }
}