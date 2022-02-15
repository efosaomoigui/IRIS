using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.UpdatePrice
{
    public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, UpdatePriceCommandResponse>
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdatePriceCommandHandler(IPriceEntRepository priceRepository, IMapper mapper, IEmailService emailService)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdatePriceCommandResponse> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            var UpdatePriceCommandResponse = new UpdatePriceCommandResponse();
            var validator = new UpdatePriceCommandValidator(_priceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdatePriceCommandResponse.Success = false;
                UpdatePriceCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdatePriceCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdatePriceCommandResponse.Success)
            {
                var updatePrice = _mapper.Map<PriceEnt>(request);
                await _priceRepository.UpdateAsync(updatePrice);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdatePriceCommandResponse.Pricedto = _mapper.Map<PriceDto>(updatePrice);

                return UpdatePriceCommandResponse;
            }

            UpdatePriceCommandResponse.Pricedto = new PriceDto();
            return UpdatePriceCommandResponse;
        }
    }
}