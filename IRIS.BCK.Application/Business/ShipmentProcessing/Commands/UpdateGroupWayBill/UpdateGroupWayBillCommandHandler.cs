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

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateGroupWayBill
{
    public class UpdateGroupWayBillCommandHandler : IRequestHandler<UpdateGroupWayBillCommand, UpdateGroupWayBillCommandResponse>
    {
        private readonly IGroupWayBillRepository _groupWayBillRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateGroupWayBillCommandHandler(IGroupWayBillRepository groupWayBillRepository, IMapper mapper, IEmailService emailService)
        {
            _groupWayBillRepository = groupWayBillRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateGroupWayBillCommandResponse> Handle(UpdateGroupWayBillCommand request, CancellationToken cancellationToken)
        {
            var UpdateGroupWayBillCommandResponse = new UpdateGroupWayBillCommandResponse();
            var validator = new UpdateGroupWayBillCommandValidator(_groupWayBillRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateGroupWayBillCommandResponse.Success = false;
                UpdateGroupWayBillCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateGroupWayBillCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateGroupWayBillCommandResponse.Success)
            {
                var updateGroup = _mapper.Map<GroupWayBill>(request);
                await _groupWayBillRepository.UpdateAsync(updateGroup);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateGroupWayBillCommandResponse.GroupWayBilldto = _mapper.Map<GroupWayBillDto>(updateGroup);

                return UpdateGroupWayBillCommandResponse;
            }

            UpdateGroupWayBillCommandResponse.GroupWayBilldto = new GroupWayBillDto();
            return UpdateGroupWayBillCommandResponse;
        }
    }
}