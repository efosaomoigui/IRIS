using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
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

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips
{
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, CreateTripCommandResponse>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IManifestRepository _manifestRepository; 
        private readonly IGroupWayBillRepository _groupwaybillRepository; 
        private readonly IShipmentRepository _shipmentRepository; 
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly INumberEntRepository _numberEntRepository;

        public CreateTripCommandHandler(ITripRepository tripRepository, IMapper mapper, IEmailService emailService, INumberEntRepository numberEntRepository, IManifestRepository manifestRepository = null, IGroupWayBillRepository groupwaybillRepository = null, IShipmentRepository shipmentRepository = null)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _emailService = emailService;
            _numberEntRepository = numberEntRepository;
            _manifestRepository = manifestRepository;
            _groupwaybillRepository = groupwaybillRepository;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<CreateTripCommandResponse> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var CreateTripCommandResponse = new CreateTripCommandResponse();
            var validator = new CreateTripCommandValidator(_tripRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                CreateTripCommandResponse.Success = false;
                CreateTripCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    CreateTripCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            if (CreateTripCommandResponse.Success)
            {
                var trips = TripMapsCommand.CreateTripMapsCommand(request);

                foreach (var trip in trips)
                {
                    var manifest = await _manifestRepository.GetManifestByManifestCode(trip.ManifestCode);
                    trip.ManifestId = manifest.Id;
                }

                var resultTrip = await _tripRepository.AddRangeAsync(trips);

                foreach (var grp in trips)
                {
                    var manifest = await _manifestRepository.GetManifestByManifestCode(grp.ManifestCode);
                    manifest.ShipmentProcessingStatus = ShipmentProcessingStatus.Dispatched;
                    await _manifestRepository.UpdateAsync(manifest);

                    var groupWaybills = await _groupwaybillRepository.GetManifestGroupwaybillByGrpCode(manifest.GroupWayBillCode);

                    foreach (var singleGrp in groupWaybills)
                    {
                        var grpWaybills = await _groupwaybillRepository.GetGroupWaybillById(singleGrp.Id.ToString());
                        grpWaybills.ShipmentProcessingStatus = ShipmentProcessingStatus.Dispatched;
                        await _manifestRepository.UpdateAsync(manifest);

                        var updateShipment = await _shipmentRepository.GetShipmentByWayBill(singleGrp.Waybill);
                        updateShipment.ShipmentProcessingStatus = ShipmentProcessingStatus.Dispatched;
                        await _shipmentRepository.UpdateAsync(updateShipment);
                    }
                }

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (Exception)
                {
                    throw;
                }

                CreateTripCommandResponse.Tripdto = _mapper.Map<List<TripDto>>(resultTrip);

                return CreateTripCommandResponse;
            }

            return CreateTripCommandResponse;
        }
    }
}