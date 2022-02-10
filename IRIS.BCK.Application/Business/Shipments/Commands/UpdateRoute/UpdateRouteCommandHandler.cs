using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Routes;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateRoute
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, UpdateRouteCommandResponse>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateRouteCommandHandler(IRouteRepository routeRepository, IMapper mapper, IEmailService emailService)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateRouteCommandResponse> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
        {
            var UpdateRouteCommandResponse = new UpdateRouteCommandResponse();
            var validator = new UpdateRouteCommandValidator(_routeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateRouteCommandResponse.Success = false;
                UpdateRouteCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateRouteCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateRouteCommandResponse.Success)
            {
                var updateRoute = _mapper.Map<Route>(request);
                await _routeRepository.UpdateAsync(updateRoute);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateRouteCommandResponse.Routedto = _mapper.Map<RouteDto>(updateRoute);

                return UpdateRouteCommandResponse;
            }

            UpdateRouteCommandResponse.Routedto = new RouteDto();
            return UpdateRouteCommandResponse;
        }
    }
}