using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber
{
    public class GetNewWayBillNumberQueryHandler : IRequestHandler<GetNewWayBillNumberQuery, NewWayBillViewModel>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private INumberEntRepository _numberEntRepository;

        public GetNewWayBillNumberQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, INumberEntRepository numberEntRepository = null)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _numberEntRepository = numberEntRepository;
        }

        public async Task<NewWayBillViewModel> Handle(GetNewWayBillNumberQuery request, CancellationToken cancellationToken)
        {
            var WaybillNumber = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.WaybillNumber, "101").Result;

            var newWaybill = new NewWayBillViewModel();
            newWaybill.Waybill = WaybillNumber;

            var invoiceCode = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.InvoiceNumber, "101").Result;
            newWaybill.Invoice = invoiceCode;

            return newWaybill;
        }
    }


    public class GetNewWayBillNumberQuery : IRequest<NewWayBillViewModel>
    {
    }

    public class NewWayBillViewModel
    {
        public string Waybill { get; set; }
        public string Invoice { get; set; } 
    }
}