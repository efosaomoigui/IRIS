using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
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

namespace IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery
{
    public class GetWalletTransactionQueryHandler : IRequestHandler<GetWalletTransactionQuery, List<WalletTransactionViewModel>>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetWalletTransactionQueryHandler(IMapper mapper, IWalletRepository walletRepository = null, UserManager<User> userManager = null)
        {
            //_walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _walletRepository = walletRepository;
            _userManager = userManager;
        }

        public async Task<List<WalletTransactionViewModel>> Handle(GetWalletTransactionQuery request, CancellationToken cancellationToken)
        {
            //var allWalletTransaction = (await _walletTransactionRepository.GetAllAsync()).OrderBy(x => x.CreatedDate).ToList();
            var allWalletsAndTransactions = (await _walletRepository.GetWalletsTransaAndNumbers()).OrderBy(x => x.CreatedDate);
            List<WalletTransactionViewModel> listWallets = new List<WalletTransactionViewModel>();

            foreach (var wallet in allWalletsAndTransactions)
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
                        singleWalletVm.Name = user?.FirstName+" "+user?.LastName;
                        singleWalletVm.Description = walletTransactions.Description;
                        singleWalletVm.TransactionType = walletTransactions.TransactionType.ToString();
                        singleWalletVm.LineBalance = walletTransactions.LineBalance;

                        listWallets.Add(singleWalletVm);
                    }
                }
            }

            return _mapper.Map<List<WalletTransactionViewModel>>(listWallets);
        }
    }
}