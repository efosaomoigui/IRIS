using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips
{
    public class GetTripQueryHandler : IRequestHandler<GetTripQuery, List<TripListViewModel>>
    {
        private readonly IGenericRepository<Trips> _tripRepository;
        private readonly IMapper _mapper;

        public GetTripQueryHandler(IGenericRepository<Trips> tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<List<TripListViewModel>> Handle(GetTripQuery request, CancellationToken cancellationToken)
        {
            var allTrip = (await _tripRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<TripListViewModel>>(allTrip);
        }
    }
}