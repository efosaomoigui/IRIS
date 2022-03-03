using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.GroupWayBillManifestMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.CreateGroupWayBillManifestMap
{
    public class CreateGroupWayBillManifestMapCommandResponse : BaseResponse
    {
        public CreateGroupWayBillManifestMapCommandResponse() : base()
        {
        }

        public GroupWayBillManifestMapDto GroupWayBillManifestMapdto { get; set; }
    }
}