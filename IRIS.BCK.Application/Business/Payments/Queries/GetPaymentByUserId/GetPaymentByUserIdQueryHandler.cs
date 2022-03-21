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

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByUserId
{
    public class GetPaymentByUserIdQueryHandler : IRequestHandler<GetPaymentByUserIdQuery, PaymentViewModel>
    {
        private readonly IInvoiceRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentByUserIdQueryHandler(IInvoiceRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentViewModel> Handle(GetPaymentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userid = request.UserId.ToString();
            var user = await _paymentRepository.GetInvoiceByUserId(userid);

            return _mapper.Map<PaymentViewModel>(user);
        }
    }
}