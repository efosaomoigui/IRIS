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
    public class GetWalletTransactionByWalletNumberQuery : IRequest<WalletTransactionAndTotalViewModel>
    {
        public GetWalletTransactionByWalletNumberQuery(string walletnumber)
        {
            Walletnumber = walletnumber;
        }

        public string Walletnumber { get; }
    }
    public class GetWalletTransactionByWalletNumberHandler : IRequestHandler<GetWalletTransactionByWalletNumberQuery, WalletTransactionAndTotalViewModel>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetWalletTransactionByWalletNumberHandler(IMapper mapper, IWalletRepository walletRepository = null, UserManager<User> userManager = null)
        {
            //_walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _walletRepository = walletRepository;
            _userManager = userManager;
        }

        public async Task<WalletTransactionAndTotalViewModel> Handle(GetWalletTransactionByWalletNumberQuery request, CancellationToken cancellationToken)
        {
            var allWalletsAndTransactions = (await _walletRepository.GetWalletTransactionByWalletNumber(request.Walletnumber)).OrderBy(x => x.CreatedDate);
            WalletTransactionAndTotalViewModel WalletsTransAndTotal = new WalletTransactionAndTotalViewModel();

            var newList = new List<WalletTransactionViewModel>();

            if (allWalletsAndTransactions != null)
            {
                foreach (var wallet in allWalletsAndTransactions)
                {
                    WalletsTransAndTotal.TotalBalance = wallet.WalletBalance;
                    WalletsTransAndTotal.WalletTransactions = new List<WalletTransactionViewModel>();

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
                            singleWalletVm.LineBalance = walletTransactions.LineBalance;
                            singleWalletVm.CreatedDate = walletTransactions.CreatedDate;

                            WalletsTransAndTotal.WalletTransactions.Add(singleWalletVm);
                        }
                    }
                }

                if (WalletsTransAndTotal.WalletTransactions?.Count > 0)
                {
                    newList = WalletsTransAndTotal.WalletTransactions.OrderByDescending(x => x.CreatedDate).ToList();
                }
            }

            WalletsTransAndTotal.WalletTransactions = newList;
            WalletsTransAndTotal.WalletNumber = request.Walletnumber;
            return WalletsTransAndTotal;
        }
    }


}