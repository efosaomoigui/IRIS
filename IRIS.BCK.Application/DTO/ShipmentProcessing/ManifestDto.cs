using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.ShipmentProcessing
{
    public class ManifestDto
    {
        public Guid Id { get; set; }
        public string ManifestCode { get; set; }
        public string GroupWayBillCode { get; set; }
        public Guid RouteId { get; set; }
        public Guid UserId { get; set; }
        public Guid ServiceCenterId { get; set; }
    }
}