using AutoMapper;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletById
{
    public class GetWalletByIdQueryHandler : IRequestHandler<GetWalletByIdQuery, WalletViewModel>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public GetWalletByIdQueryHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<WalletViewModel> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var walletid = request.WalletNumberId.ToString();
            var wallet = await _walletRepository.GetWalletById(walletid);

            return _mapper.Map<WalletViewModel>(wallet);
        }
    }
}