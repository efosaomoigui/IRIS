using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.NumberEnt;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Mappings.Payments;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.CreateNumberEnt
{
    public class CreateNumberCommandHandler : IRequestHandler<CreateNumberCommand, CreateNumberCommandResponse>
    {
        private readonly INumberEntRepository _numberEntRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateNumberCommandHandler(INumberEntRepository numberEntRepository, IMapper mapper, IEmailService emailService)
        {
            _numberEntRepository = numberEntRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateNumberCommandResponse> Handle(CreateNumberCommand request, CancellationToken cancellationToken)
        {
            var CreateNumberCommandResponse = new CreateNumberCommandResponse();
            var validator = new CreateNumberCommandValidator(_numberEntRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateNumberCommandResponse.Success = false;
                CreateNumberCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateNumberCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateNumberCommandResponse.Success)
            {
                var numberVal = NumberMapsCommand.CreateNumberMapsCommand(request);
                var number = await _numberEntRepository.GenerateNextNumber(NumberGeneratorType.WalletNumber, "101");

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateNumberCommandResponse.NumberEntDto = _mapper.Map<NumberEntDto>(number);

                return CreateNumberCommandResponse;
            }

            CreateNumberCommandResponse.NumberEntDto = new NumberEntDto();
            return CreateNumberCommandResponse;
        }
    }
}