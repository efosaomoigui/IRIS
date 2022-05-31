using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
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

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByInvoiceCode
{
    public class GetPaymentByInvoiceCodeQueryHandler : IRequestHandler<GetPaymentByInvoiceCodeQuery, ShipmentViewModel>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetPaymentByInvoiceCodeQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper, IShipmentRepository shipmentRepository = null, IRouteRepository routeRepository = null, UserManager<User> userManager = null)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
            _routeRepository = routeRepository;
            _userManager = userManager;
        }

        public async Task<ShipmentViewModel> Handle(GetPaymentByInvoiceCodeQuery request, CancellationToken cancellationToken)
        {
            var payment = await _invoiceRepository.GetAllAsync();
            var invoice = payment.SingleOrDefault(x => x.InvoiceCode == request.InvoiceCode);
            var waybill = await _shipmentRepository.GetShipmentByWayBillNumber(invoice.WaybilNumber); 

            var singleShipmentVm = new ShipmentViewModel(); 

            if (waybill != null)
            {
                var user = await _userManager.FindByIdAsync(waybill.Customer.ToString());
                var user2 = await _userManager.FindByIdAsync(waybill.Reciever.ToString());
                var route = await _routeRepository.GetRouteById(waybill.ShipmentRouteId.ToString());
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
                singleShipmentVm.PaidStatus = invoice.Status.ToString();
            }

            return singleShipmentVm;
        }
    }
}