using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand
{
    public class CreateWalletTransactionCommandResponse : BaseResponse
    {
        public CreateWalletTransactionCommandResponse() : base()
        {
        }

        public WalletTransactionDto WalletTransactiondto { get; set; }
    }
}