using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Monitoring;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using IRIS.BCK.Core.Application.Mappings.Monitoring;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory
{
    public class CreateTrackHistoryCommandHandler : IRequestHandler<CreateTrackHistoryCommand, CreateTrackHistoryCommandResponse>
    {
        private readonly ITrackHistoryRepository _trackHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateTrackHistoryCommandHandler(ITrackHistoryRepository trackHistoryRepository, IMapper mapper, IEmailService emailService)
        {
            _trackHistoryRepository = trackHistoryRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateTrackHistoryCommandResponse> Handle(CreateTrackHistoryCommand request, CancellationToken cancellationToken)
        {
            var CreateTrackHistoryCommandResponse = new CreateTrackHistoryCommandResponse();
            var validator = new CreateTrackHistoryCommandValidator(_trackHistoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateTrackHistoryCommandResponse.Success = false;
                CreateTrackHistoryCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateTrackHistoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateTrackHistoryCommandResponse.Success)
            {
                var track = TrackHistoryMapsCommand.CreateTrackHistoryMapsCommand(request);
                track = await _trackHistoryRepository.AddAsync(track);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateTrackHistoryCommandResponse.TrackHistorydto = _mapper.Map<TrackHistoryDto>(track);

                return CreateTrackHistoryCommandResponse;
            }

            CreateTrackHistoryCommandResponse.TrackHistorydto = new TrackHistoryDto();
            return CreateTrackHistoryCommandResponse;
        }
    }
}