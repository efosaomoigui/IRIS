using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Monitoring;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.DeleteTrackHistory
{
    public class DeleteTrackHistoryCommandHandler : IRequestHandler<DeleteTrackHistoryCommand, DeleteTrackHistoryCommandResponse>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteTrackHistoryCommandHandler(ITrackHistoryRepository trackHistoryRepository, IMapper mapper, IEmailService emailService)
        {
            _trackHistoryRepository = trackHistoryRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteTrackHistoryCommandResponse> Handle(DeleteTrackHistoryCommand request, CancellationToken cancellationToken)
        {
            var DeleteTrackHistoryCommandResponse = new DeleteTrackHistoryCommandResponse();
            var validator = new DeleteTrackHistoryCommandValidator(_trackHistoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteTrackHistoryCommandResponse.Success = false;
                DeleteTrackHistoryCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteTrackHistoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteTrackHistoryCommandResponse.Success)
            {
                var deleteTrackHistory = await _trackHistoryRepository.Get(x => x.Id == request.Id);
                if (deleteTrackHistory == null) return DeleteTrackHistoryCommandResponse;

                await _trackHistoryRepository.DeleteAsync(deleteTrackHistory);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteTrackHistoryCommandResponse.TrackHistorydto = _mapper.Map<TrackHistoryDto>(deleteTrackHistory);

                return DeleteTrackHistoryCommandResponse;
            }

            DeleteTrackHistoryCommandResponse.TrackHistorydto = new TrackHistoryDto();
            return DeleteTrackHistoryCommandResponse;
        }
    }
}