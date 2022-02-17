using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateManifest
{
    public class UpdateManifestCommandHandler : IRequestHandler<UpdateManifestCommand, UpdateManifestCommandResponse>
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateManifestCommandHandler(IManifestRepository manifestRepository, IMapper mapper, IEmailService emailService)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateManifestCommandResponse> Handle(UpdateManifestCommand request, CancellationToken cancellationToken)
        {
            var UpdateManifestCommandResponse = new UpdateManifestCommandResponse();
            var validator = new UpdateManifestCommandValidator(_manifestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateManifestCommandResponse.Success = false;
                UpdateManifestCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateManifestCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateManifestCommandResponse.Success)
            {
                var updateManifest = _mapper.Map<Manifest>(request);
                await _manifestRepository.UpdateAsync(updateManifest);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateManifestCommandResponse.Manifestdto = _mapper.Map<ManifestDto>(updateManifest);

                return UpdateManifestCommandResponse;
            }

            UpdateManifestCommandResponse.Manifestdto = new ManifestDto();
            return UpdateManifestCommandResponse;
        }
    }
}