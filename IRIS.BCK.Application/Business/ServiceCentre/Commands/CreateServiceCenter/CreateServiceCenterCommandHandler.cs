using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ServiceCentre;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using IRIS.BCK.Core.Application.Mappings.ServiceCentre;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.CreateServiceCenter
{
    public class CreateServiceCenterCommandHandler : IRequestHandler<CreateServiceCenterCommand, CreateServiceCenterCommandResponse>
    {
        private readonly IServiceCenterRepository _serviceCenterRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateServiceCenterCommandHandler(IServiceCenterRepository serviceCenterRepository, IMapper mapper, IEmailService emailService)
        {
            _serviceCenterRepository = serviceCenterRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateServiceCenterCommandResponse> Handle(CreateServiceCenterCommand request, CancellationToken cancellationToken)
        {
            var CreateServiceCenterCommandResponse = new CreateServiceCenterCommandResponse();
            var validator = new CreateServiceCenterCommandValidator(_serviceCenterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateServiceCenterCommandResponse.Success = false;
                CreateServiceCenterCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateServiceCenterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateServiceCenterCommandResponse.Success)
            {
                var service = ServiceCenterMapsCommand.CreateServiceCenterMapsCommand(request);
                service = await _serviceCenterRepository.AddAsync(service);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateServiceCenterCommandResponse.ServiceCenterdto = _mapper.Map<ServiceCenterDto>(service);

                return CreateServiceCenterCommandResponse;
            }

            CreateServiceCenterCommandResponse.ServiceCenterdto = new ServiceCenterDto();
            return CreateServiceCenterCommandResponse;
        }
    }
}