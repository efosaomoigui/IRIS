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

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentLog
{
    public class GetPaymentLogQueryHandler : IRequestHandler<GetPaymentLogQuery, List<PaymentLogViewModel>>
    {
        private readonly IGenericRepository<PaymentLog> _paymentLogRepository;
        private readonly IMapper _mapper;

        public GetPaymentLogQueryHandler(IGenericRepository<PaymentLog> paymentLogRepository, IMapper mapper)
        {
            _paymentLogRepository = paymentLogRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentLogViewModel>> Handle(GetPaymentLogQuery request, CancellationToken cancellationToken)
        {
            var allPaymentLog = (await _paymentLogRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<PaymentLogViewModel>>(allPaymentLog);
        }
    }
}