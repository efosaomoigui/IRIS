using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList
{
    class GetShipmentListQueryHandler : IRequestHandler<GetShipmentListQuery, List<ShipmentListViewModel>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetShipmentListQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, UserManager<User> userManager = null, IRouteRepository routeRepository = null)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _routeRepository = routeRepository;
        }

        public async Task<List<ShipmentListViewModel>> Handle(GetShipmentListQuery request, CancellationToken cancellationToken)
            {
            var allShiments = (await _shipmentRepository.GetShipmentAndItemsAndRoute()).OrderByDescending(x => x.CreatedDate); 
             
            List<ShipmentListViewModel> listShipments = new List<ShipmentListViewModel>(); 

            foreach (var shipment in allShiments) 
            {
                var singleShipmentVm = new ShipmentListViewModel();

                singleShipmentVm.ShipmentId = shipment.ShipmentId;
                singleShipmentVm.Waybill = shipment.Waybill;
                singleShipmentVm.Customer = shipment.Customer;
                singleShipmentVm.CustomerAddress = shipment.CustomerAddress;
                singleShipmentVm.Reciever = shipment.Reciever;
                singleShipmentVm.RecieverAddress = shipment.RecieverAddress;
                var user = await _userManager.FindByIdAsync(shipment.Customer.ToString());
                var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(shipment.ShipmentRouteId.ToString()); 
                singleShipmentVm.Departure = route.Departure;
                singleShipmentVm.Destination = route.Destination;
                singleShipmentVm.PickupOptions = shipment.PickupOptions.ToString();
                singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                singleShipmentVm.RecieverName = shipment.RecieverName;
                singleShipmentVm.GrandTotal = shipment.GrandTotal;
                singleShipmentVm.CreatedDate = shipment.CreatedDate;
                singleShipmentVm.RecieverPhoneNumber = user2.PhoneNumber;
                singleShipmentVm.CustomerPhoneNumber = user.PhoneNumber;
                singleShipmentVm.ShipmentCategory = shipment.ShipmentCategory.ToString();
                singleShipmentVm.ShipmentOption = shipment.ShipmentOption.ToString();

                listShipments.Add(singleShipmentVm);
            }

            //return _mapper.Map<List<WalletNumberViewModel>>(allWalletNumber);
            return listShipments;
            //return _mapper.Map<List<ShipmentListViewModel>>(allShiments);
        }

    }

    class GetDashboardShipmentListQueryHandler : IRequestHandler<GetDashboardShipmentListQuery, List<DashboardShipmentListViewModel>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetDashboardShipmentListQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, UserManager<User> userManager = null, IRouteRepository routeRepository = null)
        {
            _shipmentRepository = shipmentRepository; 
            _mapper = mapper;
            _userManager = userManager;
            _routeRepository = routeRepository;
        }

        public async Task<List<DashboardShipmentListViewModel>> Handle(GetDashboardShipmentListQuery request, CancellationToken cancellationToken)
        {
            var allShiments = (await _shipmentRepository.GetMonthlyShipmentByCreatedDate());
            return allShiments;
        }
    }

    class GetUserDashboardShipmentListQueryHandler : IRequestHandler<GetUserDashboardShipmentListQuery, List<DashboardShipmentListViewModel>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserDashboardShipmentListQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, UserManager<User> userManager = null, IRouteRepository routeRepository = null)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _userManager = userManager; 
            _routeRepository = routeRepository;
        }

        public async Task<List<DashboardShipmentListViewModel>> Handle(GetUserDashboardShipmentListQuery request, CancellationToken cancellationToken)
        {
            var allShiments = (await _shipmentRepository.GetUserMonthlyShipmentByCreatedDate(request.userId));
            return allShiments;
        }
    }

    class GetUserShipmentListQueryHandler : IRequestHandler<GetUserShipmentListQuery, List<ShipmentListViewModel>>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserShipmentListQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, UserManager<User> userManager = null, IRouteRepository routeRepository = null)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper; 
            _userManager = userManager;
            _routeRepository = routeRepository;
        }

        public async Task<List<ShipmentListViewModel>> Handle(GetUserShipmentListQuery request, CancellationToken cancellationToken)
        {
            var allShiments = (await _shipmentRepository.GetUserShipmentAndItemsAndRoute(request.userId)).OrderByDescending(x => x.CreatedDate); 

            List<ShipmentListViewModel> listShipments = new List<ShipmentListViewModel>();

            foreach (var shipment in allShiments)
            {
                var singleShipmentVm = new ShipmentListViewModel();

                singleShipmentVm.ShipmentId = shipment.ShipmentId;
                singleShipmentVm.Waybill = shipment.Waybill;
                singleShipmentVm.Customer = shipment.Customer;
                singleShipmentVm.CustomerAddress = shipment.CustomerAddress;
                singleShipmentVm.Reciever = shipment.Reciever;
                singleShipmentVm.RecieverAddress = shipment.RecieverAddress;
                var user = await _userManager.FindByIdAsync(shipment.Customer.ToString());
                var user2 = await _userManager.FindByIdAsync(shipment.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(shipment.ShipmentRouteId.ToString());
                singleShipmentVm.Departure = route.Departure;
                singleShipmentVm.Destination = route.Destination;
                singleShipmentVm.PickupOptions = shipment.PickupOptions.ToString();
                singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
                singleShipmentVm.RecieverName = shipment.RecieverName;
                singleShipmentVm.GrandTotal = shipment.GrandTotal;
                singleShipmentVm.GrandTotal = shipment.GrandTotal;
                singleShipmentVm.CreatedDate = shipment.CreatedDate;
                singleShipmentVm.RecieverPhoneNumber = user2.PhoneNumber;
                singleShipmentVm.CustomerPhoneNumber = user.PhoneNumber;
                singleShipmentVm.ShipmentCategory = shipment.ShipmentCategory.ToString();
                singleShipmentVm.ShipmentOption = shipment.ShipmentOption.ToString();

                listShipments.Add(singleShipmentVm);
            }

            //return _mapper.Map<List<WalletNumberViewModel>>(allWalletNumber);
            return listShipments;
            //return _mapper.Map<List<ShipmentListViewModel>>(allShiments);
        }
    }
}
