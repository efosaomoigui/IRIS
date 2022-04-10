using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public GetWalletNumberQueryHandler(IWalletRepository walletRepository, IMapper mapper, UserManager<User> userManager = null)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<WalletNumberViewModel>> Handle(GetWalletNumberQuery request, CancellationToken cancellationToken)
        {
            var allWalletNumber = (await _walletRepository.GetWalletsTransaAndNumbers()).OrderBy(x => x.CreatedDate);
            List<WalletNumberViewModel> listWallets = new List<WalletNumberViewModel>();

            foreach (var wallet in allWalletNumber)
            {
                var singleWalletVm = new WalletNumberViewModel();

                singleWalletVm.Id = wallet.Id;
                singleWalletVm.Number = wallet.Number;
                singleWalletVm.UserId = wallet.UserId;
                var user = await _userManager.FindByIdAsync(wallet.UserId.ToString());
                singleWalletVm.WalletBalance = wallet.WalletBalance;
                singleWalletVm.User = user?.FirstName + " " + user?.LastName;

                listWallets.Add(singleWalletVm);
            }

            //return _mapper.Map<List<WalletNumberViewModel>>(allWalletNumber);
            return listWallets;
        }
    }
}