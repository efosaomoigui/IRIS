using AutoMapper;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceById
{
    public class GetPriceByIdQueryHandler : IRequestHandler<GetPriceByIdQuery, PriceViewModel>
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IMapper _mapper;

        public GetPriceByIdQueryHandler(IPriceEntRepository priceRepository, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
        }

        public async Task<PriceViewModel> Handle(GetPriceByIdQuery request, CancellationToken cancellationToken)
        {
            var priceid = request.Id.ToString();
            var price = await _priceRepository.GetPriceById(priceid);

            return _mapper.Map<PriceViewModel>(price);
        }
    }
}