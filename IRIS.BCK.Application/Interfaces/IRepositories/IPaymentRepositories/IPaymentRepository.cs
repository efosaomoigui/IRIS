using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        public Task<Payment> GetPaymentById(string id);

        public Task<Payment> GetPaymentByInvoiceCode(string invoicecode);
    }
}