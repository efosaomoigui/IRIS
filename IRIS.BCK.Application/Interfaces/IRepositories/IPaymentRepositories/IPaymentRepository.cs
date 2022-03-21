using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories
{
    public interface IPaymentRepository : IGenericRepository<Invoice>
    {
        public Task<Invoice> GetPaymentById(string id);

        public Task<Invoice> GetPaymentByInvoiceCode(string invoicecode);

        public Task<Invoice> GetPaymentByUserId(string userid);
    }
}