using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentGroupWayBill;
using IRIS.BCK.Core.Domain.Entities.ShipmentGroupWayBillMapEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.UpdateShipmentGroupWayBillMap
{
    public class UpdateShipmentGroupWayBillMapCommandHandler : IRequestHandler<UpdateShipmentGroupWayBillMapCommand, UpdateShipmentGroupWayBillMapCommandResponse>
    {
        private readonly IShipmentGroupWayBillMapRepository _shipmentGroupWayBillRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UpdateShipmentGroupWayBillMapCommandHandler(IShipmentGroupWayBillMapRepository shipmentGroupWayBillRepository, IMapper mapper, IEmailService emailService)
        {
            _shipmentGroupWayBillRepository = shipmentGroupWayBillRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<UpdateShipmentGroupWayBillMapCommandResponse> Handle(UpdateShipmentGroupWayBillMapCommand request, CancellationToken cancellationToken)
        {
            var UpdateShipmentGroupWayBillMapCommandResponse = new UpdateShipmentGroupWayBillMapCommandResponse();
            var validator = new UpdateShipmentGroupWayBillMapCommandValidator(_shipmentGroupWayBillRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                UpdateShipmentGroupWayBillMapCommandResponse.Success = false;
                UpdateShipmentGroupWayBillMapCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    UpdateShipmentGroupWayBillMapCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (UpdateShipmentGroupWayBillMapCommandResponse.Success)
            {
                var updateShipmentGroup = _mapper.Map<ShipmentGroupWayBillMap>(request);
                await _shipmentGroupWayBillRepository.UpdateAsync(updateShipmentGroup);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                UpdateShipmentGroupWayBillMapCommandResponse.ShipmentGroupWayBillMapdto = _mapper.Map<ShipmentGroupWayBillMapDto>(updateShipmentGroup);

                return UpdateShipmentGroupWayBillMapCommandResponse;
            }

            UpdateShipmentGroupWayBillMapCommandResponse.ShipmentGroupWayBillMapdto = new ShipmentGroupWayBillMapDto();
            return UpdateShipmentGroupWayBillMapCommandResponse;
        }
    }
}