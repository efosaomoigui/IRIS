using AutoMapper;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPaymentRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentViewModel>
    {
        private readonly IInvoiceRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentByIdQueryHandler(IInvoiceRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentViewModel> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var paymentid = request.Id.ToString();
            var payment = await _paymentRepository.GetInvoiceById(paymentid);

            return _mapper.Map<PaymentViewModel>(payment);
        }
    }
}