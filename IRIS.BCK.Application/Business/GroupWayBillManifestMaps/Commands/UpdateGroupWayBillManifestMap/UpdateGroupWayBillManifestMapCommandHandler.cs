using AutoMapper;
using IRIS.BCK.Core.Application.DTO.GroupWayBillManifestMap;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IGroupWayBillManifest;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.UpdateGroupWayBillManifestMap
{
    public class UpdateGroupWayBillManifestMapCommandHandler : IRequestHandler<UpdateGroupWayBillManifestMapComand, UpdateGroupWayBillManifestMapCommandResponse>
    {
        private readonly IGroupWayBillManifestMapRepository _groupWayBillManifestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateGroupWayBillManifestMapCommandHandler(IGroupWayBillManifestMapRepository groupWayBillManifestRepository, IMapper mapper, IEmailService emailService)
        {
            _groupWayBillManifestRepository = groupWayBillManifestRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateGroupWayBillManifestMapCommandResponse> Handle(UpdateGroupWayBillManifestMapComand request, CancellationToken cancellationToken)
        {
            var UpdateGroupWayBillManifestMapCommandResponse = new UpdateGroupWayBillManifestMapCommandResponse();
            var validator = new UpdateGroupWayBillManifestMapCommandValidator(_groupWayBillManifestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateGroupWayBillManifestMapCommandResponse.Success = false;
                UpdateGroupWayBillManifestMapCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateGroupWayBillManifestMapCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateGroupWayBillManifestMapCommandResponse.Success)
            {
                var updateGroupWayBill = _mapper.Map<GroupWayBillManifestMap>(request);
                await _groupWayBillManifestRepository.UpdateAsync(updateGroupWayBill);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateGroupWayBillManifestMapCommandResponse.GroupWayBillManifestMapdto = _mapper.Map<GroupWayBillManifestMapDto>(updateGroupWayBill);

                return UpdateGroupWayBillManifestMapCommandResponse;
            }

            UpdateGroupWayBillManifestMapCommandResponse.GroupWayBillManifestMapdto = new GroupWayBillManifestMapDto();
            return UpdateGroupWayBillManifestMapCommandResponse;
        }
    }
}