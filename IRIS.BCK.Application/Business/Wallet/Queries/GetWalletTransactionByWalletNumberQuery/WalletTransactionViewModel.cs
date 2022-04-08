using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery
{
    public class WalletTransactionViewModel
    {
        public Guid Id { get; set; }
        public string WalletNumber { get; set; } 
        public string Name { get; set; }  
        public string Amount { get; set; }
        public string TransactionType { get; set; } 
        public string Description { get; set; }
        public decimal LineBalance { get; set; }
        public decimal WalletBalance { get; set; }
        public Guid UserId { get; set; }
    }
}