using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ServiceCentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.DeleteServiceCenter
{
    public class DeleteServiceCenterCommandResponse : BaseResponse
    {
        public DeleteServiceCenterCommandResponse() : base()
        {
        }

        public ServiceCenterDto ServiceCenterdto { get; set; }
    }
}