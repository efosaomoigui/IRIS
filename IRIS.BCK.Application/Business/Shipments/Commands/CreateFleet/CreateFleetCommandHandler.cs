using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Fleets;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using IRIS.BCK.Core.Application.Mappings.Settings;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets
{
    public class CreateFleetCommandHandler : IRequestHandler<CreateFleetCommand, CreateFleetCommandResponse>
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateFleetCommandHandler(IFleetRepository fleetRepository, IMapper mapper, IEmailService emailService)
        {
            _fleetRepository = fleetRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateFleetCommandResponse> Handle(CreateFleetCommand request, CancellationToken cancellationToken)
        {
            var CreateFleetCommandResponse = new CreateFleetCommandResponse();
            var validator = new CreateFleetCommandValidator(_fleetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateFleetCommandResponse.Success = false;
                CreateFleetCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateFleetCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateFleetCommandResponse.Success)
            {
                var fleet = SettingsMapsCommand.CreateFleetMapsCommand(request);
                //var fleet = _mapper.Map<Fleet>(request);
                fleet = await _fleetRepository.AddAsync(fleet);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateFleetCommandResponse.Fleetdto = _mapper.Map<FleetDto>(fleet);

                return CreateFleetCommandResponse;
            }

            CreateFleetCommandResponse.Fleetdto = new FleetDto();
            return CreateFleetCommandResponse;
        }
    }
}