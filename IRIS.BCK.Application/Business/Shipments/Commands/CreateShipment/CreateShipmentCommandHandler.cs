using AutoMapper;
using IRIS.BCK.Application.Exceptions;
using IRIS.BCK.Application.Interfaces.Pesistence;
using IRIS.BCK.Application.Interfaces.Pesistence.IShipment;
using IRIS.BCK.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Business.Shipments.Commands.CreateShipment
{
    class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, int>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateShipmentCommandValidator(_shipmentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var shipment = _mapper.Map<Shipment>(request);
            shipment = await _shipmentRepository.AddAsync(shipment);
            return shipment.Id;
        }
    }
}
    