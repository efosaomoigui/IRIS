using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.DeleteCollectionCenter
{
    public class DeleteCollectionCenterCommand
    {
        public int ShipmentId { get; set; }
    }
}