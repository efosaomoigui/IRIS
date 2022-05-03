using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.ComponentModel.DataAnnotations;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets
{
    public class FleetListViewModel
    {
        public Guid FleetId { get; set; }

        [MaxLength(100)]
        public string RegistrationNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string Status { get; set; }
        public string FleetType { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public string FleetModel { get; set; }
        public string FleetMake { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; } 
    }
}