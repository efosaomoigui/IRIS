using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ShipmentProcessing
{
    public class Manifest : Auditable
    {
        public Guid Id { get; set; }
        public string ManifestCode { get; set; }
        public Guid ServiceCenterId { get; set; } 
    }
}