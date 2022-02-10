using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Routes;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IRouteRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteRoute
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, DeleteRouteCommandResponse>
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteRouteCommandHandler(IRouteRepository routeRepository, IMapper mapper, IEmailService emailService)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteRouteCommandResponse> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
        {
            var DeleteRouteCommandResponse = new DeleteRouteCommandResponse();
            var validator = new DeleteRouteCommandValidator(_routeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteRouteCommandResponse.Success = false;
                DeleteRouteCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteRouteCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteRouteCommandResponse.Success)
            {
                var deleteShipment = await _routeRepository.Get(x => x.RouteId == request.Id);
                if (deleteShipment == null) return DeleteRouteCommandResponse;

                await _routeRepository.DeleteAsync(deleteShipment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteRouteCommandResponse.Routedto = _mapper.Map<RouteDto>(deleteShipment);

                return DeleteRouteCommandResponse;
            }

            DeleteRouteCommandResponse.Routedto = new RouteDto();
            return DeleteRouteCommandResponse;
        }
    }
}