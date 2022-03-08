using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.UpdateGroupWayBillManifestMap
{
    public class UpdateGroupWayBillManifestMapComand : IRequest<UpdateGroupWayBillManifestMapCommandResponse>
    {
        public Guid GroupWayBillManifestMapid { get; set; }
        public string GroupWayBillCode { get; set; }
        public string ManifestCode { get; set; }
    }
}
