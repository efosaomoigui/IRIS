using AutoMapper;
using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.DTO.Message;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
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
        private readonly IEmailService _emailService;

        public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, IEmailService emailService)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _emailService = emailService;
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

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateShipmentCommandResponse.Success)
            {
                var shipment = _mapper.Map<Shipment>(request);
                shipment = await _shipmentRepository.AddAsync(shipment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateShipmentCommandResponse.Shipmentdto = _mapper.Map<ShipmentDto>(shipment);

                return CreateShipmentCommandResponse;
            }

            CreateShipmentCommandResponse.Shipmentdto = new ShipmentDto();
            return CreateShipmentCommandResponse;


        }

    }
}
    