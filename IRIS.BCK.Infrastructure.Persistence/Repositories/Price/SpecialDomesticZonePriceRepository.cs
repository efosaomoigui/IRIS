using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Price
{
    public class SpecialDomesticZonePriceRepository : GenericRepository<SpecialDomesticZonePrice>, ISpecialDomesticZonePriceRepository
    {
        public SpecialDomesticZonePriceRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}