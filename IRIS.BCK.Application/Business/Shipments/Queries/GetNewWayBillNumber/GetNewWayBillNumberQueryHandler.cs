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

    //Group Number
    public class GetNewGroupWayBillNumberQueryHandler : IRequestHandler<GetNewGroupWayBillNumberQuery, string>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private INumberEntRepository _numberEntRepository;

        public GetNewGroupWayBillNumberQueryHandler(IMapper mapper, INumberEntRepository numberEntRepository = null)
        {
            _mapper = mapper;
            _numberEntRepository = numberEntRepository;
        } 

        public async Task<string> Handle(GetNewGroupWayBillNumberQuery request, CancellationToken cancellationToken)
        {
            var BroupWaybillNumber = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.GroupWaybillNumber, "101").Result;
            return BroupWaybillNumber;
        }
    }

    public class GetNewGroupWayBillNumberQuery : IRequest<string>
    {
    }

    //Manifest Number
    public class GetNewManifestNumberQueryHandler : IRequestHandler<GetNewManifestNumberQuery, string>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private INumberEntRepository _numberEntRepository;

        public GetNewManifestNumberQueryHandler(IMapper mapper, INumberEntRepository numberEntRepository = null)
        {
            _mapper = mapper;
            _numberEntRepository = numberEntRepository;
        }

        public async Task<string> Handle(GetNewManifestNumberQuery request, CancellationToken cancellationToken)
        {
            var BroupWaybillNumber = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.ManifestNumber, "101").Result;
            return BroupWaybillNumber;
        }
    }

    public class GetNewManifestNumberQuery : IRequest<string>
    {
    }

    //Manifest Number
    public class GetNewTripReferenceQueryHandler : IRequestHandler<GetNewTripReferenceQuery, string>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private INumberEntRepository _numberEntRepository;

        public GetNewTripReferenceQueryHandler(IMapper mapper, INumberEntRepository numberEntRepository = null)
        {
            _mapper = mapper;
            _numberEntRepository = numberEntRepository;
        }

        public async Task<string> Handle(GetNewTripReferenceQuery request, CancellationToken cancellationToken)
        {
            var BroupWaybillNumber = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.TripReference, "101").Result;
            return BroupWaybillNumber;
        }
    }

    public class GetNewTripReferenceQuery : IRequest<string>
    {
    }
}