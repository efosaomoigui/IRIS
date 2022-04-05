using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using IRIS.BCK.Core.Domain.Entities.NumberEnt;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Payments
{
    public class NumberEntRepository : GenericRepository<NumberEnt>, INumberEntRepository
    {
        private IServiceCenterRepository _serviceCenterRepository;

        public NumberEntRepository(IRISDbContext dbContext, IServiceCenterRepository serviceCenterRepository) : base(dbContext)
        {
            _serviceCenterRepository = serviceCenterRepository;
        }


        public Task<NumberEnt> AddNumberEnt(string id)
        {
            throw new NotImplementedException();
        }

        public async Task AddNumberGeneratorMonitor(string serviceCenterCode, NumberGeneratorType numberGeneratorType, string numberStr)
        {
            await _dbContext.NumberEnt.AddAsync(new NumberEnt
            {
                ServiceCentreCode = serviceCenterCode,
                NumberGeneratorType = numberGeneratorType, 
                NumberCode = numberStr
            });
        }

        public async Task<string> GenerateNextNumber(NumberGeneratorType numberGeneratorType, string serviceCenterCode)
        {
            try
            {
                string numberGenerated = null;

                //pad the service centre
                var serviceCenterVal = await _serviceCenterRepository.GetAllAsync();
                var serviceCenter = serviceCenterVal.ToList().FirstOrDefault(x => x.ServiceCode == serviceCenterCode);

                var serviceCentreCode = (serviceCenter == null) ? 101 : int.Parse(serviceCenter.ServiceCode);
                var codeStr = serviceCentreCode.ToString("000");

                //1. Get the last numberGenerated for the serviceCenter and numberGeneratorType
                //from the NumberGeneratorMonitor Table
                var monitor = _dbContext.NumberEnt.SingleOrDefault(x =>
                    x.ServiceCentreCode == serviceCenterCode && x.NumberGeneratorType == numberGeneratorType);

                // At this point, monitor can only be null if it's the first time we're
                // creating a number for the service centre and numberGeneratorType. 
                //If that's the case, we assume our numberCode to be "0".
                var numberCode = monitor?.NumberCode ?? "0";

                //2. Increment lastcode to get the next available numberCode by 1
                var number = 0L;
                var numberStr = "";

                if (numberGeneratorType == NumberGeneratorType.WalletNumber)
                {
                    number = long.Parse(numberCode) + 1;
                    numberStr = number.ToString("000000");
                    numberGenerated = (int)NumberGeneratorType.WalletNumber + codeStr + numberStr;
                }
                else if (numberGeneratorType == NumberGeneratorType.WaybillNumber)
                {
                    number = long.Parse(numberCode) + 1;
                    numberStr = number.ToString("000000");
                    numberGenerated = (int)NumberGeneratorType.WaybillNumber + codeStr + numberStr;
                }
                else if (numberGeneratorType == NumberGeneratorType.ManifestNumber)
                {
                    number = long.Parse(numberCode) + 1;
                    numberStr = number.ToString("000000");
                    numberGenerated = (int)NumberGeneratorType.ManifestNumber + codeStr + numberStr;
                }
                else if (numberGeneratorType == NumberGeneratorType.GroupWaybillNumber)
                {
                    number = long.Parse(numberCode) + 1;
                    numberStr = number.ToString("000000");
                    numberGenerated = (int)NumberGeneratorType.GroupWaybillNumber + codeStr + numberStr;
                }
                else if (numberGeneratorType == NumberGeneratorType.TripReference)
                {
                    number = long.Parse(numberCode) + 1;
                    numberStr = number.ToString("0000");
                    numberGenerated = (int)NumberGeneratorType.TripReference + codeStr + numberStr;
                }
                else if (numberGeneratorType == NumberGeneratorType.InvoiceNumber)
                {
                    number = long.Parse(numberCode) + 1;
                    numberStr = number.ToString("0000");
                    numberGenerated = (int)NumberGeneratorType.InvoiceNumber + codeStr + numberStr;
                }
                else
                {
                    number = long.Parse(numberCode) + 1;
                    numberStr = number.ToString("000000");
                    numberGenerated = (int)NumberGeneratorType.Default + codeStr + numberStr;
                }

                //Add or update the NumberGeneratorMonitor Table for the Service Centre and numberGeneratorType
                if (monitor != null)
                {
                    await UpdateNumberGeneratorMonitor(serviceCenterCode, numberGeneratorType, numberStr);
                }
                else
                {
                    await AddNumberGeneratorMonitor(serviceCenterCode, numberGeneratorType, numberStr);
                }

                return numberGenerated;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public string SubNumberGenerator(int numberGeneratorType, strin)
        //{
        //    var numberGenerated = "";
        //    number = long.Parse(numberCode) + 1;
        //    numberStr = number.ToString("0000");
        //    numberGenerated = NumberGeneratorType.WalletNumber + codeStr + numberStr;
        //    return numberGenerated;
        //}

        public async Task UpdateNumberGeneratorMonitor(string serviceCenterCode, NumberGeneratorType numberGeneratorType, string numberStr)
        {
            var monitor = _dbContext.NumberEnt.SingleOrDefault(x => x.ServiceCentreCode == serviceCenterCode && x.NumberGeneratorType == numberGeneratorType);
            monitor.NumberCode = numberStr;
        }
    }
}