using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Application.Mappings.Monitoring;
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
        private readonly ITrackHistoryRepository _trackHistoryRepository; 
        private IMediator _mediator;

        public CreateTripCommandHandler(ITripRepository tripRepository, IMapper mapper, IEmailService emailService, INumberEntRepository numberEntRepository, IManifestRepository manifestRepository = null, IGroupWayBillRepository groupwaybillRepository = null, IShipmentRepository shipmentRepository = null, IMediator mediator = null, ITrackHistoryRepository trackHistoryRepository = null)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _emailService = emailService;
            _numberEntRepository = numberEntRepository;
            _manifestRepository = manifestRepository;
            _groupwaybillRepository = groupwaybillRepository;
            _shipmentRepository = shipmentRepository;
            _mediator = mediator;
            _trackHistoryRepository = trackHistoryRepository;
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
                    var manifest = await _manifestRepository.GetManifestByManifestCodeSignle(trip.ManifestCode);
                    trip.ManifestId = manifest.Id;
                }

                var resultTrip = await _tripRepository.AddRangeAsync(trips);
                var manifestLists = trips.Select(x => x.ManifestCode).ToList();  

                //Add Track
                var track = TrackHistoryMapsCommand.CreateTrackHistoryMapsCommandTripReg(request);
                track = await _trackHistoryRepository.AddAsync(track);

                var manifestList = await _manifestRepository.GetManifestByManifestCodeList(manifestLists);

                foreach (var manifest in manifestList) 
                {
                    manifest.ShipmentProcessingStatus = ShipmentProcessingStatus.Dispatched;
                }

                await _manifestRepository.UpdateRangeAsync(manifestList);

                var listGroupWaybills = manifestList.Select(x => x.GroupWayBillCode).ToList();
                var groupWaybills = await _groupwaybillRepository.GetManifestGroupwaybillByListCode(listGroupWaybills);

                foreach (var grp in groupWaybills)
                {
                    grp.ShipmentProcessingStatus = ShipmentProcessingStatus.Dispatched;
                }

                await _groupwaybillRepository.UpdateRangeAsync(groupWaybills);

                var strWaybills = groupWaybills.Select(x => x.Waybill).ToList();
                var shipments = _shipmentRepository.GetShipmentByWayBillUsingListWaybills(strWaybills).Result;

                foreach (var way in shipments) 
                {
                    way.ShipmentProcessingStatus = ShipmentProcessingStatus.Dispatched;
                }

                await _shipmentRepository.UpdateRangeAsync(shipments);

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