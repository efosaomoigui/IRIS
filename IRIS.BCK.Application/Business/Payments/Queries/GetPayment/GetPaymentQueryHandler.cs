using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, List<PaymentListViewModel>>
    {
        private readonly IGenericRepository<Payment> _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentQueryHandler(IGenericRepository<Payment> paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentListViewModel>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var allPayments = (await _paymentRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<PaymentListViewModel>>(allPayments);
        }
    }
}