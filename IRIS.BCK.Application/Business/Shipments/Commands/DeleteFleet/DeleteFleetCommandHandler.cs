using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Fleets;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteFleet
{
    public class DeleteFleetCommandHandler : IRequestHandler<DeleteFleetCommand, DeleteFleetCommandResponse>
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteFleetCommandHandler(IFleetRepository fleetRepository, IMapper mapper, IEmailService emailService)
        {
            _fleetRepository = fleetRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteFleetCommandResponse> Handle(DeleteFleetCommand request, CancellationToken cancellationToken)
        {
            var DeleteFleetCommandResponse = new DeleteFleetCommandResponse();
            var validator = new DeleteFleetCommandValidator(_fleetRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteFleetCommandResponse.Success = false;
                DeleteFleetCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteFleetCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteFleetCommandResponse.Success)
            {
                var deleteFleet = await _fleetRepository.Get(x => x.FleetId == request.FleetId);
                if (deleteFleet == null) return DeleteFleetCommandResponse;

                await _fleetRepository.DeleteAsync(deleteFleet);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteFleetCommandResponse.Fleetdto = _mapper.Map<FleetDto>(deleteFleet);

                return DeleteFleetCommandResponse;
            }

            DeleteFleetCommandResponse.Fleetdto = new FleetDto();
            return DeleteFleetCommandResponse;
        }
    }
}