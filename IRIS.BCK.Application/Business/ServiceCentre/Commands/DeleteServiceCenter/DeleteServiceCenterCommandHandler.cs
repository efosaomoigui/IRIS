using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ServiceCentre;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.DeleteServiceCenter
{
    public class DeleteServiceCenterCommandHandler : IRequestHandler<DeleteServiceCenterCommand, DeleteServiceCenterCommandResponse>
    {
        private readonly IServiceCenterRepository _serviceCenterRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteServiceCenterCommandHandler(IServiceCenterRepository serviceCenterRepository, IMapper mapper, IEmailService emailService)
        {
            _serviceCenterRepository = serviceCenterRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteServiceCenterCommandResponse> Handle(DeleteServiceCenterCommand request, CancellationToken cancellationToken)
        {
            var DeleteServiceCenterCommandResponse = new DeleteServiceCenterCommandResponse();
            var validator = new DeleteServiceCenterCommandValidator(_serviceCenterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteServiceCenterCommandResponse.Success = false;
                DeleteServiceCenterCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteServiceCenterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteServiceCenterCommandResponse.Success)
            {
                var deleteServiceCenter = await _serviceCenterRepository.Get(x => x.ServiceCenterId == request.ServiceCenterId);
                if (deleteServiceCenter == null) return DeleteServiceCenterCommandResponse;

                await _serviceCenterRepository.DeleteAsync(deleteServiceCenter);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteServiceCenterCommandResponse.ServiceCenterdto = _mapper.Map<ServiceCenterDto>(deleteServiceCenter);

                return DeleteServiceCenterCommandResponse;
            }

            DeleteServiceCenterCommandResponse.ServiceCenterdto = new ServiceCenterDto();
            return DeleteServiceCenterCommandResponse;
        }
    }
}