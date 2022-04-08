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
    public class GetWalletNumberQueryHandler : IRequestHandler<GetWalletNumberQuery, List<WalletTransactionViewModel>>
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

        public async Task<List<WalletTransactionViewModel>> Handle(GetWalletNumberQuery request, CancellationToken cancellationToken)
        {
            var allWalletNumber = (await _walletRepository.GetWalletsTransaAndNumbers()).OrderBy(x => x.CreatedDate);
            List<WalletTransactionViewModel> listWallets = new List<WalletTransactionViewModel>();

            foreach (var wallet in allWalletNumber)
            {
                if (wallet.WalletTransactions.Count > 0)
                {
                    foreach (var walletTransactions in wallet.WalletTransactions)
                    {
                        var singleWalletVm = new WalletTransactionViewModel();

                        singleWalletVm.Id = walletTransactions.Id;
                        singleWalletVm.WalletNumber = wallet.Number;
                        singleWalletVm.UserId = walletTransactions.UserId;
                        var user = await _userManager.FindByIdAsync(walletTransactions.UserId.ToString());
                        singleWalletVm.Amount = walletTransactions.Amount.ToString();
                        singleWalletVm.Name = user?.FirstName + " " + user?.LastName;
                        singleWalletVm.Description = walletTransactions.Description;
                        singleWalletVm.TransactionType = walletTransactions.TransactionType.ToString();

                        listWallets.Add(singleWalletVm);
                    }
                }
            }

            return _mapper.Map<List<WalletTransactionViewModel>>(listWallets);
            //return _mapper.Map<List<WalletNumberViewModel>>(allWalletNumber);
        }
    }
}