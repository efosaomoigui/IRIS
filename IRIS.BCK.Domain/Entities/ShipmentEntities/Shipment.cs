using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.ShimentEntities
{
    public class Shipment : Auditable
    {
        public int Id { get; set; }
        public string waybill { get; set; }
        public int FirstName { get; set; }
    }
}