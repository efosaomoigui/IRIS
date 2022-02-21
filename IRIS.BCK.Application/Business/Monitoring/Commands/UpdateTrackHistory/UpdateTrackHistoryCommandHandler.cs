using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Monitoring;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.UpdateTrackHistory
{
    public class UpdateTrackHistoryCommandHandler : IRequestHandler<UpdateTrackHistoryCommand, UpdateTrackHistoryCommandResponse>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateTrackHistoryCommandHandler(ITrackHistoryRepository trackHistoryRepository, IMapper mapper, IEmailService emailService)
        {
            _trackHistoryRepository = trackHistoryRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateTrackHistoryCommandResponse> Handle(UpdateTrackHistoryCommand request, CancellationToken cancellationToken)
        {
            var UpdateTrackHistoryCommandResponse = new UpdateTrackHistoryCommandResponse();
            var validator = new UpdateTrackHistoryCommandValidator(_trackHistoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateTrackHistoryCommandResponse.Success = false;
                UpdateTrackHistoryCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateTrackHistoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateTrackHistoryCommandResponse.Success)
            {
                var updatePayment = _mapper.Map<TrackHistory>(request);
                await _trackHistoryRepository.UpdateAsync(updatePayment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateTrackHistoryCommandResponse.TrackHistorydto = _mapper.Map<TrackHistoryDto>(updatePayment);

                return UpdateTrackHistoryCommandResponse;
            }

            UpdateTrackHistoryCommandResponse.TrackHistorydto = new TrackHistoryDto();
            return UpdateTrackHistoryCommandResponse;
        }
    }
}