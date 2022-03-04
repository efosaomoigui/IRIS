using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities
{
    public class GroupWayBillManifestMap : Auditable
    {
        public Guid GroupWayBillManifestMapid { get; set; }
        public string GroupWayBillCode { get; set; }
        public string ManifestCode { get; set; }
    }
}