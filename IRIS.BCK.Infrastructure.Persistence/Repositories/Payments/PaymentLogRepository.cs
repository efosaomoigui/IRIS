using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Payments
{
    public class PaymentLogRepository : GenericRepository<PaymentLog>, IPaymentLogRepository
    {
        public PaymentLogRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}