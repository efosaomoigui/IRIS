using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ShipmentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetCollectionCenter
{
    public class GetCollectionCenterQueryHandler : IRequestHandler<GetCollectionCenterQuery, List<CollectionCenterListViewModel>>
    {
        private readonly IGenericRepository<CollectionCenter> _centerRepository;
        private readonly IMapper _mapper;

        public GetCollectionCenterQueryHandler(IGenericRepository<CollectionCenter> centerRepository, IMapper mapper)
        {
            _centerRepository = centerRepository;
            _mapper = mapper;
        }

        public async Task<List<CollectionCenterListViewModel>> Handle(GetCollectionCenterQuery request, CancellationToken cancellationToken)
        {
            var allCenter = (await _centerRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<CollectionCenterListViewModel>>(allCenter);
        }
    }
}