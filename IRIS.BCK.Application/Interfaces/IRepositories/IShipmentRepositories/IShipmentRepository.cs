using IRIS.BCK.Application.DTO;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories
{
    public interface IShipmentRepository : IGenericRepository<Shipment>
    {
        Task<bool> CheckUniqueWaybillNumber(string waybill);

        Task<bool> CheckUniqueWaybillNumberFiftyCharacterslong(string waybill);

        Task<Shipment> GetShipmentById(string shipmentid);

        Task<Shipment> GetShipmentByWayBillNumber(string waybillnumber);
    }
}