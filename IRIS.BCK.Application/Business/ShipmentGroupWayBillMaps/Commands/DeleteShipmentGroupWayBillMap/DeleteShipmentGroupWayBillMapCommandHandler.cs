using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentGroupWayBill;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.DeleteShipmentGroupWayBillMap
{
    public class DeleteShipmentGroupWayBillMapCommandHandler : IRequestHandler<DeleteShipmentGroupWayBillMapCommand, DeleteShipmentGroupWayBillMapCommandResponse>
    {
        private readonly IShipmentGroupWayBillMapRepository _shipmentGroupWayBillRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteShipmentGroupWayBillMapCommandHandler(IShipmentGroupWayBillMapRepository shipmentGroupWayBillRepository, IMapper mapper, IEmailService emailService)
        {
            _shipmentGroupWayBillRepository = shipmentGroupWayBillRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteShipmentGroupWayBillMapCommandResponse> Handle(DeleteShipmentGroupWayBillMapCommand request, CancellationToken cancellationToken)
        {
            var DeleteShipmentGroupWayBillMapCommandResponse = new DeleteShipmentGroupWayBillMapCommandResponse();
            var validator = new DeleteShipmentGroupWayBillMapCommandValidator(_shipmentGroupWayBillRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteShipmentGroupWayBillMapCommandResponse.Success = false;
                DeleteShipmentGroupWayBillMapCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteShipmentGroupWayBillMapCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteShipmentGroupWayBillMapCommandResponse.Success)
            {
                var deleteShipmentGroup = await _shipmentGroupWayBillRepository.Get(x => x.id == request.id);
                if (deleteShipmentGroup == null) return DeleteShipmentGroupWayBillMapCommandResponse;

                await _shipmentGroupWayBillRepository.DeleteAsync(deleteShipmentGroup);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteShipmentGroupWayBillMapCommandResponse.ShipmentGroupWayBillMapdto = _mapper.Map<ShipmentGroupWayBillMapDto>(deleteShipmentGroup);

                return DeleteShipmentGroupWayBillMapCommandResponse;
            }

            DeleteShipmentGroupWayBillMapCommandResponse.ShipmentGroupWayBillMapdto = new ShipmentGroupWayBillMapDto();
            return DeleteShipmentGroupWayBillMapCommandResponse;
        }
    }
}