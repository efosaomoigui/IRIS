using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletByWalletNumberQuery
{
    public class GetWalletNumberQueryHandler : IRequestHandler<GetWalletNumberQuery, List<WalletNumberViewModel>>
    {
        private readonly IWalletRepository _walletRepository; 
        private readonly IMapper _mapper;

        public GetWalletNumberQueryHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<List<WalletNumberViewModel>> Handle(GetWalletNumberQuery request, CancellationToken cancellationToken)
        {
            var allWalletNumber = (await _walletRepository.GetWalletsTransaAndNumbers()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<WalletNumberViewModel>>(allWalletNumber);
        }
    }
}