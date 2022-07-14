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
    public class GetManifestGroupwaybillByRouteIdQueryHandler : IRequestHandler<GetManifestGroupwaybillByRouteIdQuery, List<GroupWayBillListViewModel>>
    {
        private readonly IGroupWayBillRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetManifestGroupwaybillByRouteIdQueryHandler(IGroupWayBillRepository groupRepository, IMapper mapper)   
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<List<GroupWayBillListViewModel>> Handle(GetManifestGroupwaybillByRouteIdQuery request, CancellationToken cancellationToken)
        {
            var allGroup =  await _groupRepository.GetManifestGroupwaybillByRouteId(request.RouteId.ToString());
            return allGroup;
        }
    }    
    
    public class GetManifestGroupwaybillByCodeQueryHandler : IRequestHandler<GetManifestGroupwaybillByGroupQuery, List<GroupWayBillListViewModel>>
    {
        private readonly IGroupWayBillRepository _groupRepository;
        private readonly IMapper _mapper;

        public GetManifestGroupwaybillByCodeQueryHandler(IGroupWayBillRepository groupRepository, IMapper mapper)    
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<List<GroupWayBillListViewModel>> Handle(GetManifestGroupwaybillByGroupQuery request, CancellationToken cancellationToken)
        {
            var allGroup =  await _groupRepository.GetManifestGroupwaybillByGrpCode(request.GroupCode);
            return allGroup;
        }
    }
}