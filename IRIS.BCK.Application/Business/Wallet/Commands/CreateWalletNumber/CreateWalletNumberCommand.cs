using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
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
        public Guid Id { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
        public string WalletBalance { get; set; }

        //public User UserId { get; set; }
    }
}