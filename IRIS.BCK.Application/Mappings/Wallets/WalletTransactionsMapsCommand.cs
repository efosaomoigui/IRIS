using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
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
                UserId = request.UserId
            };
        }

        public static WalletTransaction CreateWalletTransactionsCriteriaMapsCommand(PaymentCriteriaCommand request)  
        {
            return new WalletTransaction
            {
                Amount = request.Amount,
                TransactionType = request.WalletTransactionType,
                Description = request.Description,
                UserId = (Guid)request.UserId
            };
        }
    }
}