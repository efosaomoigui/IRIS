using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment
{
    public class PaymentListViewModel
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string InvoiceCode { get; set; }
        public Guid UserId { get; set; }
        public string WaybilNumber { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StatusEnum Status { get; set; }
    }
}