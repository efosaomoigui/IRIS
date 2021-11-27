using IRIS.BCK.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Interfaces.Pesistence.IShipment 
{
    interface IShipmentRepository : IGenericRepository<Shipment>
    {
        Task<bool> CheckUniqueWaybillNumber(string waybill);
    }
}
