using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.DeletePrice
{
    public class DeletePriceCommandHandler : IRequestHandler<DeletePriceCommand, DeletePriceCommandResponse>
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeletePriceCommandHandler(IPriceEntRepository priceRepository, IMapper mapper, IEmailService emailService)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeletePriceCommandResponse> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
        {
            var DeletePriceCommandResponse = new DeletePriceCommandResponse();
            var validator = new DeletePriceCommandValidator(_priceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeletePriceCommandResponse.Success = false;
                DeletePriceCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeletePriceCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeletePriceCommandResponse.Success)
            {
                var deletePrice = await _priceRepository.Get(x => x.Id == request.Id);
                if (deletePrice == null) return DeletePriceCommandResponse;

                await _priceRepository.DeleteAsync(deletePrice);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeletePriceCommandResponse.Pricedto = _mapper.Map<PriceDto>(deletePrice);

                return DeletePriceCommandResponse;
            }

            DeletePriceCommandResponse.Pricedto = new PriceDto();
            return DeletePriceCommandResponse;
        }
    }
}