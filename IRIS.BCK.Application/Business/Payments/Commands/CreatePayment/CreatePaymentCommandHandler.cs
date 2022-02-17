using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Mappings.Payment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper, IEmailService emailService)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var CreatePaymentCommandResponse = new CreatePaymentCommandResponse();
            var validator = new CreatePaymentCommandValidator(_paymentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreatePaymentCommandResponse.Success = false;
                CreatePaymentCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreatePaymentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreatePaymentCommandResponse.Success)
            {
                var payment = PaymentMapsCommand.CreatePaymentMapsCommand(request);
                //var fleet = _mapper.Map<Fleet>(request);
                payment = await _paymentRepository.AddAsync(payment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreatePaymentCommandResponse.Paymentdto = _mapper.Map<PaymentDto>(payment);

                return CreatePaymentCommandResponse;
            }

            CreatePaymentCommandResponse.Paymentdto = new PaymentDto();
            return CreatePaymentCommandResponse;
        }
    }
}