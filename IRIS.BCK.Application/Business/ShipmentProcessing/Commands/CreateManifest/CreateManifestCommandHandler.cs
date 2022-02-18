using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Application.Mappings.ShipmentProcessing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateManifest
{
    public class CreateManifestCommandHandler : IRequestHandler<CreateManifestCommand, CreateManifestCommandResponse>
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateManifestCommandHandler(IManifestRepository manifestRepository, IMapper mapper, IEmailService emailService)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateManifestCommandResponse> Handle(CreateManifestCommand request, CancellationToken cancellationToken)
        {
            var CreateManifestCommandResponse = new CreateManifestCommandResponse();
            var validator = new CreateManifestCommandValidator(_manifestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateManifestCommandResponse.Success = false;
                CreateManifestCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateManifestCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateManifestCommandResponse.Success)
            {
                var manifest = ManifestMapsCommand.CreateManifestMapsCommand(request);
                manifest = await _manifestRepository.AddAsync(manifest);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateManifestCommandResponse.Manifestdto = _mapper.Map<ManifestDto>(manifest);

                return CreateManifestCommandResponse;
            }

            CreateManifestCommandResponse.Manifestdto = new ManifestDto();
            return CreateManifestCommandResponse;
        }
    }
}