using AutoMapper;
using IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.NumberEnt;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.NumberEnt;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.UpdateNumber
{
    public class UpdateNumberCommandHandler : IRequestHandler<UpdateNumberCommand, UpdateNumberCommandResponse>
    {
        private readonly INumberEntRepository _numberEntRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateNumberCommandHandler(INumberEntRepository numberEntRepository, IMapper mapper, IEmailService emailService)
        {
            _numberEntRepository = numberEntRepository;
            _mapper = mapper;
            _emailService = emailService;
        }


        public async Task<UpdateNumberCommandResponse> Handle(UpdateNumberCommand request, CancellationToken cancellationToken)
        {
            var UpdateNumberCommandResponse = new UpdateNumberCommandResponse();
            var validator = new UpdateNumberCommandValidator(_numberEntRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateNumberCommandResponse.Success = false;
                UpdateNumberCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateNumberCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateNumberCommandResponse.Success)
            {
                var updateNumber = _mapper.Map<NumberEnt>(request);
                await _numberEntRepository.UpdateAsync(updateNumber);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateNumberCommandResponse.NumberEntDto = _mapper.Map<NumberEntDto>(updateNumber);

                return UpdateNumberCommandResponse;
            }

            UpdateNumberCommandResponse.NumberEntDto = new NumberEntDto();
            return UpdateNumberCommandResponse;
        }
    }
}