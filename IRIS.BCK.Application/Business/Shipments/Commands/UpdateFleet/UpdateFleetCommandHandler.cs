using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Fleets;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateFleet
{
    public class UpdateFleetCommandHandler : IRequestHandler<UpdateFleetCommand, UpdateFleetCommandResponse>
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateFleetCommandHandler(IFleetRepository fleetRepository, IMapper mapper, IEmailService emailService)
        {
            _fleetRepository = fleetRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateFleetCommandResponse> Handle(UpdateFleetCommand request, CancellationToken cancellationToken)
        {
            var UpdateFleetCommandResponse = new UpdateFleetCommandResponse();
            var validator = new UpdateFleetCommandValidator(_fleetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateFleetCommandResponse.Success = false;
                UpdateFleetCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateFleetCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateFleetCommandResponse.Success)
            {
                var updateFleet = _mapper.Map<Fleet>(request);
                await _fleetRepository.UpdateAsync(updateFleet);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateFleetCommandResponse.Fleetdto = _mapper.Map<FleetDto>(updateFleet);

                return UpdateFleetCommandResponse;
            }

            UpdateFleetCommandResponse.Fleetdto = new FleetDto();
            return UpdateFleetCommandResponse;
        }
    }
}