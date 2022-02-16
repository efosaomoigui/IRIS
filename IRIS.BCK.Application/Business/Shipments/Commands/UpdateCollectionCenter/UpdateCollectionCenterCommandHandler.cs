using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Shipments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateCollectionCenter
{
    public class UpdateCollectionCenterCommandHandler : IRequestHandler<UpdateCollectionCenterCommand, UpdateCollectionCenterCommandResponse>
    {
        private readonly ICollectionCenterRepository _collectionCenterRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateCollectionCenterCommandHandler(ICollectionCenterRepository collectionCenterRepository, IMapper mapper, IEmailService emailService)
        {
            _collectionCenterRepository = collectionCenterRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateCollectionCenterCommandResponse> Handle(UpdateCollectionCenterCommand request, CancellationToken cancellationToken)
        {
            var UpdateCollectionCenterCommandResponse = new UpdateCollectionCenterCommandResponse();
            var validator = new UpdateCollectionCenterCommandValidator(_collectionCenterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateCollectionCenterCommandResponse.Success = false;
                UpdateCollectionCenterCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateCollectionCenterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateCollectionCenterCommandResponse.Success)
            {
                var updateCenter = _mapper.Map<CollectionCenter>(request);
                await _collectionCenterRepository.UpdateAsync(updateCenter);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateCollectionCenterCommandResponse.CollectionCenterdto = _mapper.Map<CollectionCenterDto>(updateCenter);

                return UpdateCollectionCenterCommandResponse;
            }

            UpdateCollectionCenterCommandResponse.CollectionCenterdto = new CollectionCenterDto();
            return UpdateCollectionCenterCommandResponse;
        }
    }
}