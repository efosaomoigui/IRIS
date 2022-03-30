using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentRequests;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRequestRepositories;
using IRIS.BCK.Core.Application.Mappings.ShipmentRequests;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentRequests.Commands.CreateShipmentRequest
{
    public class CreateShipmentRequestCommandHandler : IRequestHandler<CreateShipmentRequestCommand, CreateShipmentRequestCommandResponse>
    {
        private readonly IShipmentRequestRepository _shipmentRequestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly INumberEntRepository _numberEntRepository;

        public CreateShipmentRequestCommandHandler(IShipmentRequestRepository shipmentRequestRepository, IMapper mapper, IEmailService emailService, INumberEntRepository numberEntRepository)
        {
            _shipmentRequestRepository = shipmentRequestRepository;
            _mapper = mapper;
            _emailService = emailService;
            _numberEntRepository = numberEntRepository;
        }

        public async Task<CreateShipmentRequestCommandResponse> Handle(CreateShipmentRequestCommand request, CancellationToken cancellationToken)
        {
            var CreateShipmentRequestCommandResponse = new CreateShipmentRequestCommandResponse();
            var validator = new CreateShipmentRequestCommandValidator(_shipmentRequestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateShipmentRequestCommandResponse.Success = false;
                CreateShipmentRequestCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateShipmentRequestCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateShipmentRequestCommandResponse.Success)
            {
                request.Waybill = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.WaybillNumber, "101").Result;
                var shipmentRequest = ShipmentRequestMapsCommand.CreateShipmentRequestMapsCommand(request);
                shipmentRequest = await _shipmentRequestRepository.AddAsync(shipmentRequest);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateShipmentRequestCommandResponse.ShipmentRequestdto = _mapper.Map<ShipmentRequestDto>(shipmentRequest);

                return CreateShipmentRequestCommandResponse;
            }

            CreateShipmentRequestCommandResponse.ShipmentRequestdto = new ShipmentRequestDto();
            return CreateShipmentRequestCommandResponse;
        }
    }
}