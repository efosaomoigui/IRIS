using AutoMapper;
using IRIS.BCK.Core.Application.DTO.GroupWayBillManifestMap;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IGroupWayBillManifest;
using IRIS.BCK.Core.Application.Mappings.GroupWayBillManifestM;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.CreateGroupWayBillManifestMap
{
    public class CreateGroupWayBillManifestMapCommandHandler : IRequestHandler<CreateGroupWayBillManifestMapCommand, CreateGroupWayBillManifestMapCommandResponse>
    {
        private readonly IGroupWayBillManifestMapRepository _groupWayBillManifestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateGroupWayBillManifestMapCommandHandler(IGroupWayBillManifestMapRepository groupWayBillManifestRepository, IMapper mapper, IEmailService emailService)
        {
            _groupWayBillManifestRepository = groupWayBillManifestRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateGroupWayBillManifestMapCommandResponse> Handle(CreateGroupWayBillManifestMapCommand request, CancellationToken cancellationToken)
        {
            var CreateGroupWayBillManifestMapCommandResponse = new CreateGroupWayBillManifestMapCommandResponse();
            var validator = new CreateGroupWayBillManifestMapCommandValidator(_groupWayBillManifestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateGroupWayBillManifestMapCommandResponse.Success = false;
                CreateGroupWayBillManifestMapCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateGroupWayBillManifestMapCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateGroupWayBillManifestMapCommandResponse.Success)
            {
                var groupWay = GroupWayBillManifestMapsCommand.CreateGroupWayBillManifestMapsCommand(request);
                groupWay = await _groupWayBillManifestRepository.AddAsync(groupWay);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateGroupWayBillManifestMapCommandResponse.GroupWayBillManifestMapdto = _mapper.Map<GroupWayBillManifestMapDto>(groupWay);

                return CreateGroupWayBillManifestMapCommandResponse;
            }

            CreateGroupWayBillManifestMapCommandResponse.GroupWayBillManifestMapdto = new GroupWayBillManifestMapDto();
            return CreateGroupWayBillManifestMapCommandResponse;
        }
    }
}