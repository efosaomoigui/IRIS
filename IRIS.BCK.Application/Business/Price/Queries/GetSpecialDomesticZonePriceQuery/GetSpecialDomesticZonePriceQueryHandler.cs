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

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetSpecialDomesticZonePriceQuery
{
    public class GetSpecialDomesticZonePriceQueryHandler : IRequestHandler<GetSpecialDomesticZonePriceQuery, List<SpecialDomesticZonePriceViewModel>>
    {
        private readonly IGenericRepository<SpecialDomesticZonePrice> _specialDomesticZonePriceRepository;
        private readonly IMapper _mapper;

        public GetSpecialDomesticZonePriceQueryHandler(IGenericRepository<SpecialDomesticZonePrice> specialDomesticZonePriceRepository, IMapper mapper)
        {
            _specialDomesticZonePriceRepository = specialDomesticZonePriceRepository;
            _mapper = mapper;
        }

        public async Task<List<SpecialDomesticZonePriceViewModel>> Handle(GetSpecialDomesticZonePriceQuery request, CancellationToken cancellationToken)
        {
            var allSpecialDomesticZonePrice = (await _specialDomesticZonePriceRepository.GetAllAsync()).OrderBy(x => x.Price);
            return _mapper.Map<List<SpecialDomesticZonePriceViewModel>>(allSpecialDomesticZonePrice);
        }
    }
}