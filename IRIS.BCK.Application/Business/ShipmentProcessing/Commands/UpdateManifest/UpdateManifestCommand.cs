﻿using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateManifest
{
    public class UpdateManifestCommand : IRequest<UpdateManifestCommandResponse>
    {
        public Guid Id { get; set; }
        public string ManifestCode { get; set; }
        public Guid GroupWayBillId { get; set; }
        public Guid ServiceCenterId { get; set; }
    }
}