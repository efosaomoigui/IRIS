﻿using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.PriceEntities
{
    public class PriceEnt : Auditable
    {
        //public GUID Id { get; set; }
        public int Id { get; set; }

        public PriceCategory Category { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }
        public int UnitWeight { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}