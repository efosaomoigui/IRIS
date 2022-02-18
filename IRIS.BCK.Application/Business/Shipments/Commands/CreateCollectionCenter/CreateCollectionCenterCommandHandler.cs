using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Shipments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories;
using IRIS.BCK.Core.Application.Mappings.Shipments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter
{
    public class CreateCollectionCenterCommandHandler : IRequestHandler<CreateCollectionCenterCommand, CreateCollectionCenterCommandResponse>
    {
        private readonly ICollectionCenterRepository _collectionCenterRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateCollectionCenterCommandHandler(ICollectionCenterRepository collectionCenterRepository, IMapper mapper, IEmailService emailService)
        {
            _collectionCenterRepository = collectionCenterRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateCollectionCenterCommandResponse> Handle(CreateCollectionCenterCommand request, CancellationToken cancellationToken)
        {
            var CreateCollectionCenterCommandResponse = new CreateCollectionCenterCommandResponse();
            var validator = new CreateCollectionCenterCommandValidator(_collectionCenterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateCollectionCenterCommandResponse.Success = false;
                CreateCollectionCenterCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateCollectionCenterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateCollectionCenterCommandResponse.Success)
            {
                var center = CollectionCenterMapsCommand.CreateCollectionCenterMapsCommand(request);
                center = await _collectionCenterRepository.AddAsync(center);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateCollectionCenterCommandResponse.CollectionCenterdto = _mapper.Map<CollectionCenterDto>(center);

                return CreateCollectionCenterCommandResponse;
            }

            CreateCollectionCenterCommandResponse.CollectionCenterdto = new CollectionCenterDto();
            return CreateCollectionCenterCommandResponse;
        }
    }
}