﻿using GIGL.GIGLS.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIGLS.Core.Domain
{
    public class TransitWaybillNumber : BaseDomain, IAuditable
    {
        public int TransitWaybillNumberId { get; set; }

        [MaxLength(100), MinLength(5)]
        [Index(IsUnique = true)]
        public string WaybillNumber { get; set; }

        public int ServiceCentreId { get; set; }
        public virtual ServiceCentre ServiceCentre { get; set; }

        [MaxLength(128)]
        public string UserId { get; set; }
        public bool IsGrouped { get; set; }
        public bool IsTransitCompleted { get; set; }
    }
}
