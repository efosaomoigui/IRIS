using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Routes;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using IRIS.BCK.Core.Application.Mappings.Settings;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes
{
    public class CreateRouteCommandHandler : IRequestHandler<CreateRouteCommand, CreateRouteCommandResponse>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateRouteCommandHandler(IRouteRepository routeRepository, IMapper mapper, IEmailService emailService)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateRouteCommandResponse> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
        {
            var CreateRouteCommandResponse = new CreateRouteCommandResponse();
            var validator = new CreateRouteCommandValidator(_routeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateRouteCommandResponse.Success = false;
                CreateRouteCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateRouteCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateRouteCommandResponse.Success)
            {
                var route = SettingsMapsCommand.CreateRouteMapsCommand(request);
                //var route = _mapper.Map<Route>(request);
                route = await _routeRepository.AddAsync(route);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateRouteCommandResponse.Routedto = _mapper.Map<RouteDto>(route);

                return CreateRouteCommandResponse;
            }

            CreateRouteCommandResponse.Routedto = new RouteDto();
            return CreateRouteCommandResponse;
        }
    }
}