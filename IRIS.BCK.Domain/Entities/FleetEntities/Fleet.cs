using System.ComponentModel.DataAnnotations;
using IRIS.BCK.Domain.Common;
using System;
using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;

namespace IRIS.BCK.Core.Domain.Entities.FleetEntities
{
    public class Fleet : Auditable
    {
        [Key]
        public Guid FleetId { get; set; }
        [MaxLength(100)]
        public string RegistrationNumber { get; set; }
        public string ChasisNumber { get; set; }
        public string EngineNumber { get; set; }
        public bool Status { get; set; }
        public FleetType FleetType { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public string FleetModel { get; set; }
        public string FleetMake { get; set; }
        public Guid UserId { get; set; }
    }
}