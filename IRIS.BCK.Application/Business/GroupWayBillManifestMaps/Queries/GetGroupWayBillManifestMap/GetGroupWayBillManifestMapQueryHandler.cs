using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Queries.GetGroupWayBillManifestMap
{
    public class GetGroupWayBillManifestMapQueryHandler : IRequestHandler<GetGroupWayBillManifestMapQuery, List<GroupWayBillManifestMapListViewModel>>
    {
        private readonly IGenericRepository<GroupWayBillManifestMap> _groupWaybillManifestRepository;
        private readonly IMapper _mapper;

        public GetGroupWayBillManifestMapQueryHandler(IGenericRepository<GroupWayBillManifestMap> groupWaybillManifestRepository, IMapper mapper)
        {
            _groupWaybillManifestRepository = groupWaybillManifestRepository;
            _mapper = mapper;
        }

        public async Task<List<GroupWayBillManifestMapListViewModel>> Handle(GetGroupWayBillManifestMapQuery request, CancellationToken cancellationToken)
        {
            var allGroupWayBillManifest = (await _groupWaybillManifestRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<GroupWayBillManifestMapListViewModel>>(allGroupWayBillManifest);
        }
    }
}