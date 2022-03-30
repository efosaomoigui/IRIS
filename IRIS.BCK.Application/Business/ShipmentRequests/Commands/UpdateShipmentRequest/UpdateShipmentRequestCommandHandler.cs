using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentRequests;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRequestRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentRequestEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.UpdateShipmentRequest
{
    public class UpdateShipmentRequestCommandHandler : IRequestHandler<UpdateShipmentRequestCommand, UpdateShipmentRequestCommandResponse>
    {
        private readonly IShipmentRequestRepository _shipmentRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateShipmentRequestCommandHandler(IShipmentRequestRepository shipmentRequestRepository, IMapper mapper, IEmailService emailService)
        {
            _shipmentRequestRepository = shipmentRequestRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateShipmentRequestCommandResponse> Handle(UpdateShipmentRequestCommand request, CancellationToken cancellationToken)
        {
            var UpdateShipmentRequestCommandResponse = new UpdateShipmentRequestCommandResponse();
            var validator = new UpdateShipmentRequestCommandValidator(_shipmentRequestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateShipmentRequestCommandResponse.Success = false;
                UpdateShipmentRequestCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateShipmentRequestCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateShipmentRequestCommandResponse.Success)
            {
                var updateShipmentRequest = _mapper.Map<ShipmentRequest>(request);
                await _shipmentRequestRepository.UpdateAsync(updateShipmentRequest);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateShipmentRequestCommandResponse.ShipmentRequestdto = _mapper.Map<ShipmentRequestDto>(updateShipmentRequest);

                return UpdateShipmentRequestCommandResponse;
            }

            UpdateShipmentRequestCommandResponse.ShipmentRequestdto = new ShipmentRequestDto();
            return UpdateShipmentRequestCommandResponse;
        }
    }
}