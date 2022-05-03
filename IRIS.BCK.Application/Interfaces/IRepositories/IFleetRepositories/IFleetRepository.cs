using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IFleetRepositories
{
    public interface IFleetRepository : IGenericRepository<Fleet>
    {
        Task<bool> CheckUniqueFleetId(string fleet);

        Task<Fleet> GetFleetById(string fleetid);

        Task<Fleet> GetFleetByUserId(string userid);

        Task<List<FleetListViewModel>> GetFleetWithOwner (); 
    }
}