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
        public int GroupWayBillId { get; set; }
        public GroupWayBill GroupWayBill { get; set; }
        //public User UserId { get; set; }
    }
}