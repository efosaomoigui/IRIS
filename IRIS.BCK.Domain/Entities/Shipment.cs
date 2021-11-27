using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Domain.Entities
{
    public class Shipment : Auditable
    {
        public int Id { get; set; }
    }
}
