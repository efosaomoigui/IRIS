﻿using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
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
        private readonly IGenericRepository<Shipment> _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentListQueryHandler(IGenericRepository<Shipment> shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<List<ShipmentListViewModel>> Handle(GetShipmentListQuery request, CancellationToken cancellationToken)
        {
            var allShiments = (await _shipmentRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<ShipmentListViewModel>>(allShiments);
        }
    }
}