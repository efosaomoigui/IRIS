using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletByWalletNumberQuery
{
    public class GetWalletNumberQuery : IRequest<List<WalletTransactionViewModel>>
    {
    }
}