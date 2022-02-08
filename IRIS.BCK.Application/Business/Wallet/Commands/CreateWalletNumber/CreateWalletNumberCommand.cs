using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumberCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber
{
    public class CreateWalletNumberCommand : IRequest<CreateWalletNumberCommandResponse>
    {
        public int WalletNumberId { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }

        public string UserId { get; set; }
    }
}