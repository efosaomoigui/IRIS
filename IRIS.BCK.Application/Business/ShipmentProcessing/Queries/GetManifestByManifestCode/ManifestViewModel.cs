using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByManifestCode
{
    public class ManifestViewModel
    {
        public Guid Id { get; set; }
        public string ManifestCode { get; set; }
        public Guid GroupWayBillId { get; set; }
        public Guid ServiceCenterId { get; set; }
        public List<ManifestDto> GroupWaybills { get; set; } = new List<ManifestDto>();
    }
}