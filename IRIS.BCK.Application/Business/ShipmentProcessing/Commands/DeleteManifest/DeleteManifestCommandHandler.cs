using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteManifest
{
    public class DeleteManifestCommandHandler : IRequestHandler<DeleteManifestCommand, DeleteManifestCommandResponse>
    {
        private readonly IManifestRepository _manifestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteManifestCommandHandler(IManifestRepository manifestRepository, IMapper mapper, IEmailService emailService)
        {
            _manifestRepository = manifestRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteManifestCommandResponse> Handle(DeleteManifestCommand request, CancellationToken cancellationToken)
        {
            var DeleteManifestCommandResponse = new DeleteManifestCommandResponse();
            var validator = new DeleteManifestCommandValidator(_manifestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteManifestCommandResponse.Success = false;
                DeleteManifestCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteManifestCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteManifestCommandResponse.Success)
            {
                var deleteManifest = await _manifestRepository.Get(x => x.Id == request.Id);
                if (deleteManifest == null) return DeleteManifestCommandResponse;

                await _manifestRepository.DeleteAsync(deleteManifest);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteManifestCommandResponse.Manifestdto = _mapper.Map<ManifestDto>(deleteManifest);

                return DeleteManifestCommandResponse;
            }

            DeleteManifestCommandResponse.Manifestdto = new ManifestDto();
            return DeleteManifestCommandResponse;
        }
    }
}