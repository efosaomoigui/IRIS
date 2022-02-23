using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateTrips
{
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, UpdateTripCommandResponse>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateTripCommandHandler(ITripRepository tripRepository, IMapper mapper, IEmailService emailService)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateTripCommandResponse> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var UpdateTripCommandResponse = new UpdateTripCommandResponse();
            var validator = new UpdateTripCommandValidator(_tripRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateTripCommandResponse.Success = false;
                UpdateTripCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateTripCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateTripCommandResponse.Success)
            {
                var updateTrip = _mapper.Map<Trips>(request);
                await _tripRepository.UpdateAsync(updateTrip);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateTripCommandResponse.Tripdto = _mapper.Map<TripDto>(updateTrip);

                return UpdateTripCommandResponse;
            }

            UpdateTripCommandResponse.Tripdto = new TripDto();
            return UpdateTripCommandResponse;
        }
    }
}