using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities
{
    public class ServiceCenter
    {
        public Guid ServiceCenterId { get; set; }
        public string  ServiceCenterName { get; set; } 
        public string State { get; set; } 
        public string ServiceCenterCountry { get; set; }
        public string ServiceTag { get; set; } 
    }
}
