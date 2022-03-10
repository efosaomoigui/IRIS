using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill
{
    public class GroupWayBillListViewModel
    {
        public Guid Id { get; set; }
        public string GroupCode { get; set; }
        public Guid ShipmentId { get; set; }
        public Guid UserId { get; set; }
        public Guid ServiceCenterId { get; set; }
    }
}