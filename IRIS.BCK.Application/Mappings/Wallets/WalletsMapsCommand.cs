using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Wallets
{
    public static class WalletsMapsCommand
    {
        public static WalletNumber CreateWalletsMapsCommand(CreateWalletNumberCommand request)
        {
            return new WalletNumber
            {
                Number = request.Number,
                IsActive = request.IsActive,
                WalletBalance = request.WalletBalance,
            };
        }
    }
}