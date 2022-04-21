using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, List<PaymentListViewModel>>
    {
        private readonly IInvoiceRepository _paymentRepository; 
        private readonly IShipmentRepository _shipmentRepository; 
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetPaymentQueryHandler(IMapper mapper, IInvoiceRepository paymentRepository = null, UserManager<User> userManager = null, IShipmentRepository shipmentRepository = null)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _userManager = userManager;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<List<PaymentListViewModel>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var allPayments = (await _paymentRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);

            var allInvoices = (await _paymentRepository.GetInvoiceAndItemsAndShipment()).OrderByDescending(x => x.CreatedDate);

            List<PaymentListViewModel> listInvoices = new List<PaymentListViewModel>(); 

            foreach (var invoice in allInvoices) 
            {
                var singleInvoiceVm = new PaymentListViewModel();

                singleInvoiceVm.Id = invoice.Id;
                singleInvoiceVm.InvoiceCode = invoice.InvoiceCode;
                singleInvoiceVm.WaybilNumber = invoice.WaybilNumber;
                singleInvoiceVm.UserId = invoice.UserId;
                singleInvoiceVm.Amount = invoice.Amount;

                var shipment  = await _shipmentRepository.GetShipmentByWayBill(invoice.WaybilNumber); 

                singleInvoiceVm.CustomerAddress = shipment?.CustomerAddress;
                singleInvoiceVm.ReceiverAddress = shipment?.RecieverAddress;

                //var user = await _userManager.FindByIdAsync(invoice.UserId.ToString());

                singleInvoiceVm.PaymentMethod = invoice.PaymentMethod.ToString();

                singleInvoiceVm.CustomerName = shipment?.CustomerName;
                singleInvoiceVm.ReceiverName = shipment?.RecieverName; 
                singleInvoiceVm.CreatedDate = invoice.CreatedDate;

                singleInvoiceVm.Status = invoice.Status.ToString();

                listInvoices.Add(singleInvoiceVm);
            }
            //return _mapper.Map<List<PaymentListViewModel>>(allPayments);
            return listInvoices;
        }
    }
}