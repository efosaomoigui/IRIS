using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Mappings.Price;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice
{
    public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, CreatePriceCommandResponse>
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreatePriceCommandHandler(IPriceEntRepository priceRepository, IMapper mapper, IEmailService emailService)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreatePriceCommandResponse> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            var CreatePriceCommandResponse = new CreatePriceCommandResponse();
            var validator = new CreatePriceCommandValidator(_priceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreatePriceCommandResponse.Success = false;
                CreatePriceCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreatePriceCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreatePriceCommandResponse.Success)
            {
                var price = PriceMapsCommand.CreatePriceMapsCommand(request);
                //var fleet = _mapper.Map<Fleet>(request);
                price = await _priceRepository.AddAsync(price);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreatePriceCommandResponse.pricedto = _mapper.Map<PriceDto>(price);

                return CreatePriceCommandResponse;
            }

            CreatePriceCommandResponse.pricedto = new PriceDto();
            return CreatePriceCommandResponse;
        }
    }
}