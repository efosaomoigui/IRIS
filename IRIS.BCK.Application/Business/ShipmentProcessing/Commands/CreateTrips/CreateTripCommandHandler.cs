using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Application.Mappings.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, CreateTripCommandResponse>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly INumberEntRepository _numberEntRepository;

        public CreateTripCommandHandler(ITripRepository tripRepository, IMapper mapper, IEmailService emailService, INumberEntRepository numberEntRepository)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _emailService = emailService;
            _numberEntRepository = numberEntRepository;
        }

        public async Task<CreateTripCommandResponse> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var CreateTripCommandResponse = new CreateTripCommandResponse();
            var validator = new CreateTripCommandValidator(_tripRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateTripCommandResponse.Success = false;
                CreateTripCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateTripCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateTripCommandResponse.Success)
            {
                request.TripReference = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.TripReference, "101").Result;
                var trip = TripMapsCommand.CreateTripMapsCommand(request);
                trip = await _tripRepository.AddAsync(trip);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateTripCommandResponse.Tripdto = _mapper.Map<TripDto>(trip);

                return CreateTripCommandResponse;
            }

            CreateTripCommandResponse.Tripdto = new TripDto();
            return CreateTripCommandResponse;
        }
    }
}