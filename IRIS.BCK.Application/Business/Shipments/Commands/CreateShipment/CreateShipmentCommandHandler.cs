using AutoMapper;
using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Exceptions;
using IRIS.BCK.Application.Interfaces.Pesistence;
using IRIS.BCK.Application.Interfaces.Pesistence.IShipment;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment
{
    class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, CreateShipmentCommandResponse>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<CreateShipmentCommandResponse> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            var CreateShipmentCommandResponse = new CreateShipmentCommandResponse();
            var validator = new CreateShipmentCommandValidator(_shipmentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateShipmentCommandResponse.Success = false;
                CreateShipmentCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateShipmentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (CreateShipmentCommandResponse.Success)
            {
                var shipment = _mapper.Map<Shipment>(request);
                shipment = await _shipmentRepository.AddAsync(shipment);
                CreateShipmentCommandResponse.Shipmentdto = _mapper.Map<ShipmentDto>(shipment);
            }

            return CreateShipmentCommandResponse;


        }

    }
}
    