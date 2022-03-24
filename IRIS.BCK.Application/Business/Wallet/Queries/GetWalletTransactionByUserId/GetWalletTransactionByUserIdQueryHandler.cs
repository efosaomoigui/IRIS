using AutoMapper;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByUserId
{
    public class GetWalletTransactionByUserIdQueryHandler : IRequestHandler<GetWalletTransactionByUserIdQuery, List<WalletTransactionViewModel>>
    {
        private readonly IWalletTransactionRepository _walletTransactionRepository;
        private readonly IMapper _mapper;

        public GetWalletTransactionByUserIdQueryHandler(IWalletTransactionRepository walletTransactionRepository, IMapper mapper)
        {
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
        }

        public async Task<List<WalletTransactionViewModel>> Handle(GetWalletTransactionByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userid = request.UserId.ToString();
            var user = await _walletTransactionRepository.GetWalletTransactionByUserId(userid);

            return _mapper.Map<List<WalletTransactionViewModel>>(user);
        }
    }
}