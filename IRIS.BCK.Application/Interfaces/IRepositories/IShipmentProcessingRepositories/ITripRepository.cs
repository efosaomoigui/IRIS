using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories
{
    public interface ITripRepository : IGenericRepository<Trips>
    {
        Task<List<TripListViewModel>> GetTripManifestByRouteId();
        Task<List<TripListViewModel>> GetTripByReferenceCode(string code);
    }
}