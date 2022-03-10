using AutoMapper;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByInvoiceCode
{
    public class GetPaymentByInvoiceCodeQueryHandler : IRequestHandler<GetPaymentByInvoiceCodeQuery, PaymentViewModel>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentByInvoiceCodeQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentViewModel> Handle(GetPaymentByInvoiceCodeQuery request, CancellationToken cancellationToken)
        {
            var invoicecode = request.InvoiceCode.ToString();
            var code = await _paymentRepository.GetPaymentById(invoicecode);

            return _mapper.Map<PaymentViewModel>(code);
        }
    }
}