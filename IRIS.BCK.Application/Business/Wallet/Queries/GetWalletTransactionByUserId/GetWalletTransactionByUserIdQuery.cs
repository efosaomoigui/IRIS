using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByUserId
{
    public class GetWalletTransactionByUserIdQuery : IRequest<WalletTransactionViewModel>
    {
        public Guid UserId { get; set; }

        public GetWalletTransactionByUserIdQuery(string userid)
        {
            Guid UserGuid = new Guid(userid);
            UserId = UserGuid;
        }
    }
}