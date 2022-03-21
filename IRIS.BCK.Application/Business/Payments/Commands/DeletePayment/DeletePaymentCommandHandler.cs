using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, DeletePaymentCommandResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper, IEmailService emailService)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeletePaymentCommandResponse> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var DeletePaymentCommandResponse = new DeletePaymentCommandResponse();
            var validator = new DeletePaymentCommandValidator(_paymentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeletePaymentCommandResponse.Success = false;
                DeletePaymentCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeletePaymentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeletePaymentCommandResponse.Success)
            {
                var deletePayment = await _paymentRepository.Get(x => x.Id == request.Id);
                if (deletePayment == null) return DeletePaymentCommandResponse;

                await _paymentRepository.DeleteAsync(deletePayment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeletePaymentCommandResponse.Paymentdto = _mapper.Map<InvoiceDto>(deletePayment);

                return DeletePaymentCommandResponse;
            }

            DeletePaymentCommandResponse.Paymentdto = new InvoiceDto();
            return DeletePaymentCommandResponse;
        }
    }
}