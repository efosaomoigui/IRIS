using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletById
{
    public class GetWalletByIdQuery : IRequest<WalletViewModel>
    {
        public Guid WalletNumberId { get; set; }

        public GetWalletByIdQuery(string walletid)
        {
            Guid WalletNumberGuid = new Guid(walletid);
            WalletNumberId = WalletNumberGuid;
        }
    }
}