using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips
{
    public class CreateTripCommandResponse : BaseResponse
    {
        public CreateTripCommandResponse() : base()
        {
        }

        public TripDto Tripdto { get; set; }
    }
}