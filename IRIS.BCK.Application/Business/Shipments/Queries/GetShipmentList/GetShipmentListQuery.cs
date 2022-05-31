using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList
{
    public class GetShipmentListQuery : IRequest<List<ShipmentListViewModel>>
    {
    }

    public class GetUserShipmentListQuery : IRequest<List<ShipmentListViewModel>> 
    {
        public string userId;

        public GetUserShipmentListQuery(string userId = null)
        {
            this.userId = userId;
        }
    }

    public class GetDashboardShipmentListQuery : IRequest<List<DashboardShipmentListViewModel>> 
    {
    }    
    
    public class GetUserDashboardShipmentListQuery : IRequest<List<DashboardShipmentListViewModel>>  
    {
        public string userId;
        public GetUserDashboardShipmentListQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
