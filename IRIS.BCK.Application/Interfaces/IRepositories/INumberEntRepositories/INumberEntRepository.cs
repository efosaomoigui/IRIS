using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.NumberEnt;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository 
{
    public interface INumberEntRepository : IGenericRepository<NumberEnt> 
    {
        public Task<Payment> AddNumberEnt(string id);
        public Task<string> GenerateNextNumber(NumberGeneratorType numberGeneratorType, string serviceCenterCode);
        public Task UpdateNumberGeneratorMonitor(string serviceCenterCode, NumberGeneratorType numberGeneratorType, string numberStr);
        public Task AddNumberGeneratorMonitor(string serviceCenterCode, NumberGeneratorType numberGeneratorType, string numberStr);
    }
}