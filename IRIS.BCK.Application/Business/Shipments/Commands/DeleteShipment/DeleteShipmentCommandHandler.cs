using AutoMapper;
using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, DeleteShipmentCommandResponse>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, IEmailService emailService)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<DeleteShipmentCommandResponse> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            var DeleteShipmentCommandResponse = new DeleteShipmentCommandResponse();
            var validator = new DeleteShipmentCommandValidator(_shipmentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                DeleteShipmentCommandResponse.Success = false;
                DeleteShipmentCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    DeleteShipmentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (DeleteShipmentCommandResponse.Success)
            {
                var deleteShipment = await _shipmentRepository.Get(x => x.ShipmentId == request.Id);
                if (deleteShipment == null) return DeleteShipmentCommandResponse;

                await _shipmentRepository.DeleteAsync(deleteShipment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                DeleteShipmentCommandResponse.Shipmentdto = _mapper.Map<ShipmentDto>(deleteShipment);

                return DeleteShipmentCommandResponse;
            }

            DeleteShipmentCommandResponse.Shipmentdto = new ShipmentDto();
            return DeleteShipmentCommandResponse;
        }
    }
}