﻿using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateManifest
{
    public class CreateManifestCommand : IRequest<CreateManifestCommandResponse>
    {
        public Guid Id { get; set; }
        public string ManifestCode { get; set; }
        public List<BaseGroupWaybill> GroupWayBillCode { get; set; }
        public Guid RouteId { get; set; }
        public Guid UserId { get; set; }
        public Guid ServiceCenterId { get; set; }
    }

    public class BaseGroupWaybill
    {
        public string groupCode { get; set; }  
        public string Destination { get; set; }
        public string RouteId { get; set; }
    }
}