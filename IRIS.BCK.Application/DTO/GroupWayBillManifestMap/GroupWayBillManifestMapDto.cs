using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.GroupWayBillManifestMap
{
    public class GroupWayBillManifestMapDto
    {
        public Guid id { get; set; }
        public string GroupWayBillCode { get; set; }
        public string ManifestCode { get; set; }
    }
}