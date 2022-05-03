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

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips
{
    public class GetTripQueryHandler : IRequestHandler<GetTripQuery, List<TripListViewModel>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public GetTripQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<List<TripListViewModel>> Handle(GetTripQuery request, CancellationToken cancellationToken)
        {
            var allTrip = await _tripRepository.GetTripManifestByRouteId();
            return allTrip;
        }
    }

    public class GetTripByReferenceQueryHandler : IRequestHandler<GetTripByReferenceQuery, List<TripListViewModel>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public GetTripByReferenceQueryHandler(ITripRepository tripRepository, IMapper mapper) 
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<List<TripListViewModel>> Handle(GetTripByReferenceQuery request, CancellationToken cancellationToken)
        {
            var allTrip = await _tripRepository.GetTripByReferenceCode(request.reference);
            return allTrip;
        }
    }

    public class GetTripByReferenceQuery : IRequest<List<TripListViewModel>>
    {
        public string reference { get; set; }
        public GetTripByReferenceQuery(string reference = null)
        {
            this.reference = reference;
        }
    }
}