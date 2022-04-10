using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
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
        private readonly IPriceEntRepository _priceRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public GetPriceQueryHandler(IMapper mapper, IPriceEntRepository priceRepository = null, IRouteRepository routeRepository = null)
        {
            _mapper = mapper;
            _priceRepository = priceRepository;
            _routeRepository = routeRepository;
        }

        public async Task<List<PriceListViewModel>> Handle(GetPriceQuery request, CancellationToken cancellationToken)
        {
            //var allPrice = (await _priceRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            //return _mapper.Map<List<PriceListViewModel>>(allPrice);

            var allPrices = (await _priceRepository.GetPriceWithRoute()).OrderBy(x => x.CreatedDate).ToList();
            List<PriceListViewModel> listPrices = new List<PriceListViewModel>();

            foreach (var route in allPrices)
            { 
                foreach (var price in route.Prices)
                {
                    var singlePriceVm = new PriceListViewModel();

                    singlePriceVm.Id = price.Id;
                    singlePriceVm.Product = price.Product.ToString();
                    singlePriceVm.UnitWeight = price.UnitWeight;
                    singlePriceVm.PricePerUnit = price.PricePerUnit;
                    singlePriceVm.ShipmentCategory = price.Category.ToString();
                    singlePriceVm.Departure = route?.Departure;
                    singlePriceVm.Destination = route?.Destination;
                    singlePriceVm.RouteName = route.RouteName;
                    listPrices.Add(singlePriceVm);
                }
            }

            return listPrices;
        }
    }
}