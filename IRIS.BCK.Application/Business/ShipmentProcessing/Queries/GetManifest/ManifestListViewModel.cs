using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest
{
    public class ManifestListViewModel
    {
        public Guid Id { get; set; }
        public string ManifestCode { get; set; }
        public int GroupWayBillId { get; set; }
    }
}