using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumberCommand
{
    public class CreateWalletNumberCommandResponse : BaseResponse
    {
        public CreateWalletNumberCommandResponse() : base()
        {
        }

        public WalletNumberDto Walletdto { get; set; }
    }
}