using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Payments
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Invoice> GetInvoiceById(string id)
        {
            return _dbContext.Invoice.FirstOrDefault(e => e.Id.ToString() == id);
        }

        public async Task<Invoice> GetInvoiceByInvoiceCode(string invoicecode)
        {
            return _dbContext.Invoice.FirstOrDefault(e => e.InvoiceCode.ToString() == invoicecode);
        }

        public async Task<List<Invoice>> GetInvoiceAndItemsAndShipment()  
        {
            var lsShipments = await _dbContext.Invoice.Include(s => s.Shipment).ToListAsync();
            return lsShipments;
        }

        public async Task<Invoice> GetInvoiceByUserId(string userid)
        {
            return _dbContext.Invoice.FirstOrDefault(e => e.UserId.ToString() == userid);
        }
    }
}