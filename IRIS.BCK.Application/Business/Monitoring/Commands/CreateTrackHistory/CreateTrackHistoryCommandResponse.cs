using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory
{
    public class CreateTrackHistoryCommandResponse : BaseResponse
    {
        public CreateTrackHistoryCommandResponse() : base()
        {
        }

        public TrackHistoryDto TrackHistorydto { get; set; }
    }
}