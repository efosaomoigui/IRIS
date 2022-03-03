using IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.CreateGroupWayBillManifestMap;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.GroupWayBillManifestM
{
    public static class GroupWayBillManifestMapsCommand
    {
        public static GroupWayBillManifestMap CreateGroupWayBillManifestMapsCommand(CreateGroupWayBillManifestMapCommand request)
        {
            return new GroupWayBillManifestMap
            {
                id = request.id,
                ManifestCode = request.ManifestCode,
                GroupWayBillCode = request.GroupWayBillCode
            };
        }
    }
}