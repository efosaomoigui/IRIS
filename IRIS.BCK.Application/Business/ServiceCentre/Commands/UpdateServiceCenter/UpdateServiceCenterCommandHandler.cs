﻿using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ServiceCentre;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.UpdateServiceCenter
{
    public class UpdateServiceCenterCommandHandler : IRequestHandler<UpdateServiceCenterCommand, UpdateServiceCenterCommandResponse>
    {
        private readonly IServiceCenterRepository _serviceCenterRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateServiceCenterCommandHandler(IServiceCenterRepository serviceCenterRepository, IMapper mapper, IEmailService emailService)
        {
            _serviceCenterRepository = serviceCenterRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateServiceCenterCommandResponse> Handle(UpdateServiceCenterCommand request, CancellationToken cancellationToken)
        {
            var UpdateServiceCenterCommandResponse = new UpdateServiceCenterCommandResponse();
            var validator = new UpdateServiceCenterCommandValidator(_serviceCenterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateServiceCenterCommandResponse.Success = false;
                UpdateServiceCenterCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateServiceCenterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateServiceCenterCommandResponse.Success)
            {
                var updateServiceCenter = _mapper.Map<ServiceCenter>(request);
                await _serviceCenterRepository.UpdateAsync(updateServiceCenter);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateServiceCenterCommandResponse.ServiceCenterdto = _mapper.Map<ServiceCenterDto>(updateServiceCenter);

                return UpdateServiceCenterCommandResponse;
            }

            UpdateServiceCenterCommandResponse.ServiceCenterdto = new ServiceCenterDto();
            return UpdateServiceCenterCommandResponse;
        }
    }
}