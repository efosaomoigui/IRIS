using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill
{
    public class GetGroupWayBillQueryHandler : IRequestHandler<GetGroupWayBillQuery, List<GroupWayBillListViewModel>>
    {
        private readonly IGenericRepository<GroupWayBill> _groupRepository;
        private readonly IMapper _mapper;

        public GetGroupWayBillQueryHandler(IGenericRepository<GroupWayBill> groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<List<GroupWayBillListViewModel>> Handle(GetGroupWayBillQuery request, CancellationToken cancellationToken)
        {
            var allGroup = (await _groupRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<GroupWayBillListViewModel>>(allGroup);
        }
    }
}