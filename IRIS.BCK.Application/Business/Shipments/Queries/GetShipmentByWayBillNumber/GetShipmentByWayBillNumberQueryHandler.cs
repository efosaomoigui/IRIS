using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber
{
    public class GetShipmentByWayBillNumberQueryHandler : IRequestHandler<GetShipmentByWayBillNumberQuery, ShipmentViewModel>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IInvoiceRepository _invoiceRepository;  
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;


        public GetShipmentByWayBillNumberQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, UserManager<User> userManager = null, IRouteRepository routeRepository = null, IInvoiceRepository invoiceRepository = null)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _routeRepository = routeRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<ShipmentViewModel> Handle(GetShipmentByWayBillNumberQuery request, CancellationToken cancellationToken)
        {
            var waybillnumber = request.WayBill.ToString();
            var waybill = await _shipmentRepository.GetShipmentByWayBillNumber(waybillnumber);

            var singleShipmentVm = new ShipmentViewModel();

            var user = await _userManager.FindByIdAsync(waybill.Customer.ToString());
            var user2 = await _userManager.FindByIdAsync(waybill.Reciever.ToString());
            var route = await _routeRepository.GetRouteById(waybill.ShipmentRouteId.ToString());
            var invoice = await _invoiceRepository.GetInvoiceByUserId(waybill.Customer.ToString());
            singleShipmentVm.Departure = route.Departure;
            singleShipmentVm.Destination = route.Destination;
            singleShipmentVm.PickupOptions = waybill.PickupOptions.ToString();
            singleShipmentVm.CustomerName = user?.FirstName + " " + user?.LastName;
            singleShipmentVm.RecieverName = waybill.RecieverName;
            singleShipmentVm.RecieverPhoneNumber = user2.PhoneNumber;
            singleShipmentVm.CustomerPhoneNumber = user.PhoneNumber;
            singleShipmentVm.RecieverName = waybill.RecieverName;
            singleShipmentVm.GrandTotal = waybill.GrandTotal;
            singleShipmentVm.CustomerAddress = waybill.CustomerAddress;
            singleShipmentVm.RecieverAddress = waybill.RecieverAddress;
            singleShipmentVm.Waybill = waybill.Waybill;
            singleShipmentVm.Invoice = invoice.InvoiceCode; 
            var shipmentItems = _mapper.Map<List<ShipmentItemDto>>(waybill.ShipmentItems);
            singleShipmentVm.ShipmentItems = shipmentItems; 
            singleShipmentVm.CreatedDate = waybill.CreatedDate;
            singleShipmentVm.ShipmentCategory = waybill.ShipmentCategory.ToString();

            //return _mapper.Map<ShipmentViewModel>(waybill);
            return singleShipmentVm;
        }
    }
}