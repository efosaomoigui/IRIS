using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery
{
    public class GetWalletTransactionQueryHandler : IRequestHandler<GetWalletTransactionQuery, List<WalletTransactionViewModel>>
    {
        private readonly IGenericRepository<WalletTransaction> _walletTransactionRepository;
        private readonly IMapper _mapper;

        public GetWalletTransactionQueryHandler(IGenericRepository<WalletTransaction> walletTransactionRepository, IMapper mapper)
        {
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
        }

        public async Task<List<WalletTransactionViewModel>> Handle(GetWalletTransactionQuery request, CancellationToken cancellationToken)
        {
            var allWalletTransaction = (await _walletTransactionRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<WalletTransactionViewModel>>(allWalletTransaction);
        }
    }
}