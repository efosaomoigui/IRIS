using AutoMapper;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceById;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceByRouteId
{
    public class GetPriceByRouteIdQueryHandler : IRequestHandler<GetPriceByRouteIdQuery, PriceViewModel>
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IMapper _mapper;

        public GetPriceByRouteIdQueryHandler(IPriceEntRepository priceRepository, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
        }

        public async Task<PriceViewModel> Handle(GetPriceByRouteIdQuery request, CancellationToken cancellationToken)
        {
            var routeid = request.RouteId.ToString();
            var route = await _priceRepository.GetPriceByRouteId(routeid, request.PriceCategory);

            return _mapper.Map<PriceViewModel>(route);
        }
    }
}