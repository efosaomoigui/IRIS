using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ServiceCentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.CreateServiceCenter
{
    public class CreateServiceCenterCommandResponse : BaseResponse
    {
        public CreateServiceCenterCommandResponse() : base()
        {
        }

        public ServiceCenterDto ServiceCenterdto { get; set; }
    }
}