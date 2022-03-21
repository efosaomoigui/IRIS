using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Mappings.Payments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePaymentLog
{
    public class CreatePaymentLogCommandHandler : IRequestHandler<CreatePaymentLogCommand, CreatePaymentLogCommandResponse>
    {
        private readonly IPaymentLogRepository _paymentLogRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreatePaymentLogCommandHandler(IPaymentLogRepository paymentLogRepository, IMapper mapper, IEmailService emailService)
        {
            _paymentLogRepository = paymentLogRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreatePaymentLogCommandResponse> Handle(CreatePaymentLogCommand request, CancellationToken cancellationToken)
        {
            var CreatePaymentLogCommandResponse = new CreatePaymentLogCommandResponse();
            var validator = new CreatePaymentLogCommandValidator(_paymentLogRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreatePaymentLogCommandResponse.Success = false;
                CreatePaymentLogCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreatePaymentLogCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreatePaymentLogCommandResponse.Success)
            {
                var paymentLog = PaymentLogMapsCommand.CreatePaymentLogMapsCommand(request);
                paymentLog = await _paymentLogRepository.AddAsync(paymentLog);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreatePaymentLogCommandResponse.PaymentLogdto = _mapper.Map<PaymentLogDto>(paymentLog);

                return CreatePaymentLogCommandResponse;
            }

            CreatePaymentLogCommandResponse.PaymentLogdto = new PaymentLogDto();
            return CreatePaymentLogCommandResponse;
        }
    }
}