using IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.CreateServiceCenter;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.ServiceCentre
{
    public static class ServiceCenterMapsCommand
    {
        public static ServiceCenter CreateServiceCenterMapsCommand(CreateServiceCenterCommand request)
        {
            return new ServiceCenter
            {
                State = request.State,
                ServiceCenterName = request.ServiceCenterName,
                ServiceCenterCountry = request.ServiceCenterCountry,
                ServiceCenterId = request.ServiceCenterId
            };
        }
    }
}