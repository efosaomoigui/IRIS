using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Queries.GetServiceCenter
{
    public class GetServiceCenterQueryHandler : IRequestHandler<GetServiceCenterQuery, List<ServiceCenterListViewModel>>
    {
        private readonly IGenericRepository<ServiceCenter> _serviceCenterRepository;
        private readonly IMapper _mapper;

        public GetServiceCenterQueryHandler(IGenericRepository<ServiceCenter> serviceCenterRepository, IMapper mapper)
        {
            _serviceCenterRepository = serviceCenterRepository;
            _mapper = mapper;
        }

        public async Task<List<ServiceCenterListViewModel>> Handle(GetServiceCenterQuery request, CancellationToken cancellationToken)
        {
            var allServiceCenter = (await _serviceCenterRepository.GetAllAsync()).OrderBy(x => x.ServiceCenterName);
            return _mapper.Map<List<ServiceCenterListViewModel>>(allServiceCenter);
        }
    }
}