using AutoMapper;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Application.Mappings.Price;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem
{
    public class PriceForShipmentItemCommandHandler : IRequestHandler<PriceForShipmentItemCommand, PriceForShipmentItemCommandResponse>
    {
        private readonly IPriceEntRepository _priceRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public PriceForShipmentItemCommandHandler(IPriceEntRepository priceRepository, IMapper mapper, IEmailService emailService)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<PriceForShipmentItemCommandResponse> Handle(PriceForShipmentItemCommand request, CancellationToken cancellationToken)
        {
            var PriceForShipmentItemCommandResponse = new PriceForShipmentItemCommandResponse();
            var validator = new PriceForShipmentItemCommandValidator(_priceRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //throw new ValidationException(validationResult);
                PriceForShipmentItemCommandResponse.Success = false;
                PriceForShipmentItemCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    PriceForShipmentItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var email = new Email
            {
                To = "efe.omoigui@gmail.com",
                Body = "Test Message",
                Subject = "Test Email"
            };

            var lineItemPrice = 0M;
            //var priceTableByRouteForTrucc = 0M;
            if (PriceForShipmentItemCommandResponse.Success)
            {
                //var price = PriceMapsCommand.CreatePriceMapsCommand(request);
                if (request.ShimentCategory == ShipmentCategory.MailAndParcel)
                {
                    var priceTableByRoute = _priceRepository.GetPriceByRouteId(request.RouteId, ShipmentCategory.MailAndParcel).Result;
                    var lineItemPriceResult = _priceRepository.GetShipmentItemWeight(request).Result;
                    lineItemPrice = (priceTableByRoute==null) ? 2: priceTableByRoute.PricePerUnit * (decimal)lineItemPriceResult;
                }
                else if (request.ShimentCategory == ShipmentCategory.TruckLoad)
                {
                    var lineItemPriceResult = _priceRepository.GetPriceByRouteId(request.RouteId, ShipmentCategory.TruckLoad).Result;
                    lineItemPrice = (lineItemPriceResult == null) ? 2 :  lineItemPriceResult.PricePerUnit; 
                }
            }

            PriceForShipmentItemCommandResponse.pricedData = new PriceForShipmentItemCommand();
            PriceForShipmentItemCommandResponse.pricedData.LineTotal = lineItemPrice;
            return PriceForShipmentItemCommandResponse;
        }
    }
}