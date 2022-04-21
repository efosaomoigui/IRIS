using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery
{
    public class WalletTransactionAndTotalViewModel 
    {
        public string WalletNumber { get; set; }
        public decimal TotalBalance { get; set; }
        public List<WalletTransactionViewModel> WalletTransactions { get; set; } 
    }
}