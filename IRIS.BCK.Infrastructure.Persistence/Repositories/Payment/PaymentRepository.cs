using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Payment
{
    public class PaymentRepository : GenericRepository<Payments>, IPaymentRepository
    {
        public PaymentRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }
    }
}