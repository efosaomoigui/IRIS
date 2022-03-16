using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Payments
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Payment> GetPaymentById(string id)
        {
            return _dbContext.Payment.FirstOrDefault(e => e.Id.ToString() == id);
        }

        public async Task<Payment> GetPaymentByInvoiceCode(string invoicecode)
        {
            return _dbContext.Payment.FirstOrDefault(e => e.InvoiceCode.ToString() == invoicecode);
        }

        public async Task<Payment> GetPaymentByUserId(string userid)
        {
            return _dbContext.Payment.FirstOrDefault(e => e.UserId.ToString() == userid);
        }
    }
}