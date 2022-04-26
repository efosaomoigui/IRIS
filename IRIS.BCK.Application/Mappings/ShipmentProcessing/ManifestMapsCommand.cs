using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateManifest;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.ShipmentProcessing
{
    public static class ManifestMapsCommand
    {
        public static List<Manifest> CreateManifestMapsCommand(CreateManifestCommand request)
        {
            var listOfManifestItems = new List<Manifest>(); 

            foreach (var item in request.GroupWayBillCode)
            {
                if (item.groupCode != "")
                {
                    var grp = new Manifest
                    {
                        Id = request.Id,
                        ManifestCode = request.ManifestCode,
                        RouteId = request.RouteId,
                        UserId = request.UserId,
                        ServiceCenterId = request.ServiceCenterId,
                        GroupWayBillCode = item.groupCode
                    };

                    listOfManifestItems.Add(grp);
                }
            }

            return listOfManifestItems;
        }
    }
}