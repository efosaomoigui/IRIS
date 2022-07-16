using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Application.Mappings.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill
{
    public class CreateGroupWayBillCommandHandler : IRequestHandler<CreateGroupWayBillCommand, CreateGroupWayBillCommandResponse>
    {
        private readonly IGroupWayBillRepository _groupWayBillRepository;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateGroupWayBillCommandHandler(IGroupWayBillRepository groupWayBillRepository, IMapper mapper, IEmailService emailService, IShipmentRepository shipmentRepository = null)
        {
            _groupWayBillRepository = groupWayBillRepository;
            _mapper = mapper;
            _emailService = emailService;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<CreateGroupWayBillCommandResponse> Handle(CreateGroupWayBillCommand request, CancellationToken cancellationToken)
        {
            var CreateGroupWayBillCommandResponse = new CreateGroupWayBillCommandResponse();
            var validator = new CreateGroupWayBillCommandValidator(_groupWayBillRepository);
            var validationResult = await validator.ValidateAsync(request);

            var alreadyExistingWaybills = await _groupWayBillRepository.GetAllAsync();
            var groupCodeExist = alreadyExistingWaybills.Where(y => y.GroupCode == request.GroupCode).ToArray();
            if(groupCodeExist.Length >0) CreateGroupWayBillCommandResponse.ValidationErrors.Add("Group code exist already!");

            var requestWaybills = request.Waybills.Select(s => s.Waybill);
            var selectedWaybills = alreadyExistingWaybills.Select(x => requestWaybills.Contains(x.Waybill)).ToArray();

            //if (selectedWaybills.Length > 0) CreateGroupWayBillCommandResponse.ValidationErrors.Add("Error processing group; Waybill exist in group already!");
            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateGroupWayBillCommandResponse.Success = false;
                CreateGroupWayBillCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateGroupWayBillCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (CreateGroupWayBillCommandResponse.ValidationErrors.Count > 0)
            {
                CreateGroupWayBillCommandResponse.Success = false;
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateGroupWayBillCommandResponse.Success)
            {
                var group = GroupWayBillMapsCommand.CreateGroupWayBillMapsCommand(request);

                foreach (var grp in group)
                {
                    var shipment = await _shipmentRepository.GetShipmentByWayBillNumber(grp.Waybill);
                    grp.ShipmentId = shipment.ShipmentId;
                    grp.ShipmentProcessingStatus = ShipmentProcessingStatus.Groupped;
                }
                
                var result = await _groupWayBillRepository.AddRangeAsync(group);

                //shipment.ShipmentProcessingStatus = ShipmentProcessingStatus.Created;
                var groupShipments = group.Select(e => e.Waybill).ToList();
                var updateShipment = await _shipmentRepository.GetShipmentByWayBillUsingListWaybills(groupShipments);

                foreach (var grp in updateShipment)
                {
                    grp.ShipmentProcessingStatus = ShipmentProcessingStatus.Groupped;
                }

                await _shipmentRepository.UpdateRangeAsync(updateShipment);

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateGroupWayBillCommandResponse.GroupWayBilldto = _mapper.Map<List<GroupWayBillDto>>(result);
                return CreateGroupWayBillCommandResponse;
            }

            //CreateGroupWayBillCommandResponse.GroupWayBilldto = new GroupWayBillDto();
            return CreateGroupWayBillCommandResponse;
        }
    }
}