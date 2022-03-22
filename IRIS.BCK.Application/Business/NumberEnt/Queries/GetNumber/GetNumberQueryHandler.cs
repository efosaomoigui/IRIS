using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.NumberEnt;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Queries.GetNumber
{
    public class GetNumberQueryHandler : IRequestHandler<GetNumberQuery, List<NumberListViewModel>>
    {
        private readonly IGenericRepository<NumberEnt> _numberEntRepository; 
        private readonly IMapper _mapper;

        public GetNumberQueryHandler(IGenericRepository<NumberEnt> numberEntRepository, IMapper mapper)
        {
            _numberEntRepository = numberEntRepository;
            _mapper = mapper;
        }

        public async Task<List<NumberListViewModel>> Handle(GetNumberQuery request, CancellationToken cancellationToken)
        {
            var allNumbers = (await _numberEntRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<NumberListViewModel>>(allNumbers);
        }
    }
}