using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentGroupWayBill;
using IRIS.BCK.Core.Application.Mappings.ShipmentGroupWayBillM;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap
{
    public class CreateShipmentGroupWayBillMapHandler : IRequestHandler<CreateShipmentGroupWayBillMapCommand, CreateShipmentGroupWayBillMapResponse>
    {
        private readonly IShipmentGroupWayBillMapRepository _shipmentGroupWayBillRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateShipmentGroupWayBillMapHandler(IShipmentGroupWayBillMapRepository shipmentGroupWayBillRepository, IMapper mapper, IEmailService emailService)
        {
            _shipmentGroupWayBillRepository = shipmentGroupWayBillRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateShipmentGroupWayBillMapResponse> Handle(CreateShipmentGroupWayBillMapCommand request, CancellationToken cancellationToken)
        {
            var CreateShipmentGroupWayBillMapResponse = new CreateShipmentGroupWayBillMapResponse();
            var validator = new CreateShipmentGroupWayBillMapValidator(_shipmentGroupWayBillRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateShipmentGroupWayBillMapResponse.Success = false;
                CreateShipmentGroupWayBillMapResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateShipmentGroupWayBillMapResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateShipmentGroupWayBillMapResponse.Success)
            {
                var shipmentGroup = ShipmentGroupWayBillMapsCommand.CreateShipmentGroupWayBillMapsCommand(request);
                shipmentGroup = await _shipmentGroupWayBillRepository.AddAsync(shipmentGroup);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateShipmentGroupWayBillMapResponse.ShipmentGroupWayBillMapdto = _mapper.Map<ShipmentGroupWayBillMapDto>(shipmentGroup);

                return CreateShipmentGroupWayBillMapResponse;
            }

            CreateShipmentGroupWayBillMapResponse.ShipmentGroupWayBillMapdto = new ShipmentGroupWayBillMapDto();
            return CreateShipmentGroupWayBillMapResponse;
        }
    }
}