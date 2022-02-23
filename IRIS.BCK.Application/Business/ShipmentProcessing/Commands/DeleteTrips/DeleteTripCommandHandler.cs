using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteTrips
{
    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand, DeleteTripCommandResponse>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteTripCommandHandler(ITripRepository tripRepository, IMapper mapper, IEmailService emailService)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteTripCommandResponse> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var DeleteTripCommandResponse = new DeleteTripCommandResponse();
            var validator = new DeleteTripCommandValidator(_tripRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteTripCommandResponse.Success = false;
                DeleteTripCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteTripCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteTripCommandResponse.Success)
            {
                var deleteTrip = await _tripRepository.Get(x => x.Id == request.Id);
                if (deleteTrip == null) return DeleteTripCommandResponse;

                await _tripRepository.DeleteAsync(deleteTrip);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteTripCommandResponse.Tripdto = _mapper.Map<TripDto>(deleteTrip);

                return DeleteTripCommandResponse;
            }

            DeleteTripCommandResponse.Tripdto = new TripDto();
            return DeleteTripCommandResponse;
        }
    }
}