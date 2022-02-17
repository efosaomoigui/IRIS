using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Wallets
{
    public class WalletTransactionsMapsCommand
    {
        public static WalletTransaction CreateWalletTransactionsMapsCommand(CreateWalletTransactionCommand request)
        {
            return new WalletTransaction
            {
                Amount = request.Amount,
                TransactionType = request.TransactionType,
                Description = request.Description,
                DateCreated = request.DateCreated,
                WalletNumber = request.WalletNumber,
                //Id = request.WaybillTransactionId
            };
        }
    }
}