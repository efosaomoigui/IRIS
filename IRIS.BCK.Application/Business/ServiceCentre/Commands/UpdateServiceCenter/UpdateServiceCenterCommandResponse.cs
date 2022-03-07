using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ServiceCentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.UpdateServiceCenter
{
    public class UpdateServiceCenterCommandResponse : BaseResponse
    {
        public UpdateServiceCenterCommandResponse() : base()
        {
        }

        public ServiceCenterDto ServiceCenterdto { get; set; }
    }
}