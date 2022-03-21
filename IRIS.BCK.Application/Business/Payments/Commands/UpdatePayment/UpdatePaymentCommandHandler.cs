using AutoMapper;
using IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, UpdatePaymentCommandResponse>
    {
        private readonly IInvoiceRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdatePaymentCommandHandler(IInvoiceRepository paymentRepository, IMapper mapper, IEmailService emailService)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdatePaymentCommandResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var UpdatePaymentCommandResponse = new UpdatePaymentCommandResponse();
            var validator = new UpdatePaymentCommandValidator(_paymentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdatePaymentCommandResponse.Success = false;
                UpdatePaymentCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdatePaymentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdatePaymentCommandResponse.Success)
            {
                var updatePayment = _mapper.Map<Invoice>(request);
                await _paymentRepository.UpdateAsync(updatePayment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdatePaymentCommandResponse.Paymentdto = _mapper.Map<InvoiceDto>(updatePayment);

                return UpdatePaymentCommandResponse;
            }

            UpdatePaymentCommandResponse.Paymentdto = new InvoiceDto();
            return UpdatePaymentCommandResponse;
        }
    }
}