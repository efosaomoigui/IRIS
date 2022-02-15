using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetPrice
{
    public class GetPriceQueryHandler : IRequestHandler<GetPriceQuery, List<PriceListViewModel>>
    {
        private readonly IGenericRepository<PriceEnt> _priceRepository;
        private readonly IMapper _mapper;

        public GetPriceQueryHandler(IGenericRepository<PriceEnt> priceRepository, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
        }

        public async Task<List<PriceListViewModel>> Handle(GetPriceQuery request, CancellationToken cancellationToken)
        {
            var allPrice = (await _priceRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<PriceListViewModel>>(allPrice);
        }
    }
}