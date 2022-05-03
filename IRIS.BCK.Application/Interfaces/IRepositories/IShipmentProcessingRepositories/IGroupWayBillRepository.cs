using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories
{
    public interface IGroupWayBillRepository : IGenericRepository<GroupWayBill>
    {
        Task<List<GroupWayBillListViewModel>> GetGroupWaybillByRouteId();
        Task<List<GroupWayBillListViewModel>> GetManifestGroupwaybillByRouteId(string routeid);
        Task<List<GroupWayBillListViewModel>> GetManifestGroupwaybillByGrpCode(string routeid); 
        Task<GroupWayBillListViewModel> GetManifestGroupwaybillByCode(string routeid);
        Task<List<Guid>> GetUnprocessedGroupwaybillTRoute();

        Task<GroupWayBill> GetGroupWaybillById(string groupwaybillid);
    }
}