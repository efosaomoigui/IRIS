﻿using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets
{
    public class CreateFleetCommand : IRequest<CreateFleetCommandResponse>
    {
        public Guid FleetId { get; set; }

        [MaxLength(100)]
        public string ChassisNumber { get; set; }
        public bool Status { get; set; }
        public FleetType FleetType { get; set; }
        public int Capacity { get; set; }
        public string FleetModel { get; set; }
        public string FleetMake { get; set; }
        public Guid OwnerId { get; set; }
        public Guid UserId { get; set; }
    }
}