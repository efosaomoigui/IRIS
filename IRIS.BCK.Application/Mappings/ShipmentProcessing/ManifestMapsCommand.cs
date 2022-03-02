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
        public static Manifest CreateManifestMapsCommand(CreateManifestCommand request)
        {
            return new Manifest
            {
                ManifestCode = request.ManifestCode,
            };
        }
    }
}