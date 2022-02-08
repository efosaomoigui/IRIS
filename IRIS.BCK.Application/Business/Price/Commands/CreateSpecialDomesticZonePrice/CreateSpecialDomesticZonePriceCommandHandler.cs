using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Mappings.Price;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.SpecialDomesticZonePrice
{
    public class CreateSpecialDomesticZonePriceCommandHandler : IRequestHandler<CreateSpecialDomesticZonePriceCommand, CreateSpecialDomesticZonePriceCommandResponse>
    {
        private readonly ISpecialDomesticZonePriceRepository _specialDomesticZonePriceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateSpecialDomesticZonePriceCommandHandler(ISpecialDomesticZonePriceRepository specialDomesticZonePriceRepository, IMapper mapper, IEmailService emailService)
        {
            _specialDomesticZonePriceRepository = specialDomesticZonePriceRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateSpecialDomesticZonePriceCommandResponse> Handle(CreateSpecialDomesticZonePriceCommand request, CancellationToken cancellationToken)
        {
            var CreateSpecialDomesticZonePriceCommandResponse = new CreateSpecialDomesticZonePriceCommandResponse();
            var validator = new CreateSpecialDomesticZonePriceCommandValidator(_specialDomesticZonePriceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateSpecialDomesticZonePriceCommandResponse.Success = false;
                CreateSpecialDomesticZonePriceCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateSpecialDomesticZonePriceCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateSpecialDomesticZonePriceCommandResponse.Success)
            {
                var specialDomesticZonePriceRepository = SpecialDomesticZonePriceMapsCommand.CreateSpecialDomesticZonePriceMapsCommand(request);
                specialDomesticZonePriceRepository = await _specialDomesticZonePriceRepository.AddAsync(specialDomesticZonePriceRepository);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateSpecialDomesticZonePriceCommandResponse.specialDomesticZonePriceDto = _mapper.Map<SpecialDomesticZonePriceDto>(specialDomesticZonePriceRepository);

                return CreateSpecialDomesticZonePriceCommandResponse;
            }

            CreateSpecialDomesticZonePriceCommandResponse.specialDomesticZonePriceDto = new SpecialDomesticZonePriceDto();
            return CreateSpecialDomesticZonePriceCommandResponse;
        }
    }
}