using IRIS.BCK.Core.Domain.EntityEnums;
using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.WalletEntities
{
    public class WalletTransaction : Auditable
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public decimal LineBalance { get; set; }
         
        //Navigational Property
        public Guid WalletNumberId { get; set; } 
        public WalletNumber WalletNumber { get; set; } 
    }
}