using IRIS.BCK.Core.Domain.EntityEnums;
using System;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets
{
    public class FleetListViewModel
    {
        public int Id { get; set; }
        public string waybill { get; set; }
        public int FirstName { get; set; }
        public string RegistrationNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public bool Status { get; set; }
        public FleetType FleetType { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public string FleetModel { get; set; }
        public string FleetMake { get; set; }
        public Guid OwnerId { get; set; }
    }
}