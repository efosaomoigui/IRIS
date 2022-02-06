﻿using IRIS.BCK.Application.Interfaces.IRepository;
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
    }
}