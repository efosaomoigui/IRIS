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

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteGroupWayBill
{
    public class DeleteGroupWayBillCommandHandler : IRequestHandler<DeleteGroupWayBillCommand, DeleteGroupWayBillCommandResponse>
    {
        private readonly IGroupWayBillRepository _groupWayBillRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteGroupWayBillCommandHandler(IGroupWayBillRepository groupWayBillRepository, IMapper mapper, IEmailService emailService)
        {
            _groupWayBillRepository = groupWayBillRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteGroupWayBillCommandResponse> Handle(DeleteGroupWayBillCommand request, CancellationToken cancellationToken)
        {
            var DeleteGroupWayBillCommandResponse = new DeleteGroupWayBillCommandResponse();
            var validator = new DeleteGroupWayBillCommandValidator(_groupWayBillRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteGroupWayBillCommandResponse.Success = false;
                DeleteGroupWayBillCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteGroupWayBillCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteGroupWayBillCommandResponse.Success)
            {
                var deleteGroup = await _groupWayBillRepository.Get(x => x.Id == request.Id);
                if (deleteGroup == null) return DeleteGroupWayBillCommandResponse;

                await _groupWayBillRepository.DeleteAsync(deleteGroup);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteGroupWayBillCommandResponse.GroupWayBilldto = _mapper.Map<GroupWayBillDto>(deleteGroup);

                return DeleteGroupWayBillCommandResponse;
            }

            DeleteGroupWayBillCommandResponse.GroupWayBilldto = new GroupWayBillDto();
            return DeleteGroupWayBillCommandResponse;
        }
    }
}