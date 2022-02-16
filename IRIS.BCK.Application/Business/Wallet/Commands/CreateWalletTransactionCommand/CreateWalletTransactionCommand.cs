using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand
{
    public class CreateWalletTransactionCommand : IRequest<CreateWalletTransactionCommandResponse>
    {
        public int WaybillTransactionId { get; set; }
        public string Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string UserId { get; set; }
        public string WalletNumber { get; set; }
    }
}