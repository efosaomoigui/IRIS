using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.UpdateServiceCenter
{
    public class UpdateServiceCenterCommand : IRequest<UpdateServiceCenterCommandResponse>
    {
        public Guid ServiceCenterId { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceCenterName { get; set; }
        public string State { get; set; }
        public string ServiceCenterCountry { get; set; }
        public string ServiceTag { get; set; }
    }
}