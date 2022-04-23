﻿using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories
{
    public interface IManifestRepository : IGenericRepository<Manifest>
    {
        Task<Manifest> GetManifestByManifestCode(string manifestcode);

        Task<Manifest> GetManifestByWayBill(string waybill);

        Task<List<ManifestListViewModel>> GetManifestGroupWaybillByRouteId(); 
    }
}