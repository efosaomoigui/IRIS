﻿using AutoMapper;
using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
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

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateShipments
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, UpdateShipmentCommandResponse>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, IEmailService emailService)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateShipmentCommandResponse> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var UpdateShipmentCommandResponse = new UpdateShipmentCommandResponse();
            var validator = new UpdateShipmentCommandValidator(_shipmentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateShipmentCommandResponse.Success = false;
                UpdateShipmentCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateShipmentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateShipmentCommandResponse.Success)
            {
                var updateShipment = _mapper.Map<Shipment>(request);
                await _shipmentRepository.UpdateAsync(updateShipment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateShipmentCommandResponse.Shipmentdto = _mapper.Map<ShipmentDto>(updateShipment);

                return UpdateShipmentCommandResponse;
            }

            UpdateShipmentCommandResponse.Shipmentdto = new ShipmentDto();
            return UpdateShipmentCommandResponse;
        }
    }
}