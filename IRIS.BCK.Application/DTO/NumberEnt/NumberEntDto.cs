using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.NumberEnt
{
    public class NumberEntDto
    {
        public Guid NumberId { get; set; }
        public string ServiceCentreCode { get; set; }
        public NumberGeneratorType NumberGeneratorType { get; set; }
        public string NumberCode { get; set; } 
    }
}