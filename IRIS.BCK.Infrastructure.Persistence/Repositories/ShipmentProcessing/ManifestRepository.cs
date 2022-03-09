﻿using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.ShipmentProcessing
{
    public class ManifestRepository : GenericRepository<Manifest>, IManifestRepository
    {
        public ManifestRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Manifest> GetManifestByManifestCode(string manifestcode)
        {
            return _dbContext.Manifest.FirstOrDefault(e => e.ManifestCode.ToString() == manifestcode);
        }

        public async Task<Manifest> GetManifestByWayBill(string waybill)
        {
            return _dbContext.Manifest.FirstOrDefault(e => e.GroupWayBillId.ToString() == waybill);
        }
    }
}