using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery
{
    public class GetWalletTransactionQuery : IRequest<List<WalletTransactionViewModel>>
    {
    }

    public class GetDashboardWalletTransactionQuery : IRequest<List<DashboardShipmentListViewModel>> 
    {
    }

    public class GetUserDashboardWalletTransactionQuery : IRequest<List<DashboardShipmentListViewModel>>
    {
        public string userId;

        public GetUserDashboardWalletTransactionQuery(string userId)
        {
            this.userId = userId;
        }
    }
}