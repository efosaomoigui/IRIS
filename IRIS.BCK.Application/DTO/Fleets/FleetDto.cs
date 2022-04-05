using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Fleets
{
    public class FleetDto
    {
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
        public Guid OwnerId { get; set; }
        public Guid UserId { get; set; }
    }
}