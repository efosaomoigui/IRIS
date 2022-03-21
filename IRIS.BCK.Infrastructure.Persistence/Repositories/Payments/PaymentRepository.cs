using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Payments
{
    public class PaymentRepository : GenericRepository<Invoice>, IPaymentRepository
    {
        public PaymentRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Invoice> GetPaymentById(string id)
        {
            return _dbContext.Invoice.FirstOrDefault(e => e.Id.ToString() == id);
        }

        public async Task<Invoice> GetPaymentByInvoiceCode(string invoicecode)
        {
            return _dbContext.Invoice.FirstOrDefault(e => e.InvoiceCode.ToString() == invoicecode);
        }

        public async Task<Invoice> GetPaymentByUserId(string userid)
        {
            return _dbContext.Invoice.FirstOrDefault(e => e.UserId.ToString() == userid);
        }
    }
}