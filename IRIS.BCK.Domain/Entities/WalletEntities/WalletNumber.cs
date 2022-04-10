using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.WalletEntities
{
    public class WalletNumber : Auditable
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal WalletBalance { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }

        public Guid WalletNumberId { get; set; } 
        public List<WalletTransaction> WalletTransactions { get; set; }

    }
}