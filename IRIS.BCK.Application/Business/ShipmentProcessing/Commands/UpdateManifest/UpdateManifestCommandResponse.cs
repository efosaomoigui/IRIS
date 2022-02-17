using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateManifest
{
    public class UpdateManifestCommandResponse : BaseResponse
    {
        public UpdateManifestCommandResponse() : base()
        {
        }

        public ManifestDto Manifestdto { get; set; }
    }
}