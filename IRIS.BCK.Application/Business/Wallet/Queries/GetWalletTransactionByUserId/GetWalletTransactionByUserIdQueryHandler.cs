using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public GetWalletTransactionByUserIdQueryHandler(IWalletTransactionRepository walletTransactionRepository, IMapper mapper, UserManager<User> userManager = null)
        {
            _walletTransactionRepository = walletTransactionRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<WalletTransactionViewModel>> Handle(GetWalletTransactionByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userid = request.UserId.ToString();
            var userWalletTransaction = await _walletTransactionRepository.GetWalletTransactionByUserId(userid);

            List<WalletTransactionViewModel> vTransactions = new List<WalletTransactionViewModel>();

            foreach (var wallet in userWalletTransaction)
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
                        singleWalletVm.LineBalance = walletTransactions.LineBalance;
                        singleWalletVm.WalletBalance = wallet.WalletBalance;
                        singleWalletVm.CreatedDate = walletTransactions.CreatedDate;

                        vTransactions.Add(singleWalletVm);
                    }
                }
            }

            var newList = vTransactions.OrderByDescending(x => x.CreatedDate)
                  .ToList();
            //var walletMap = _mapper.Map<List<WalletTransactionViewModel>>(userWalletTransaction);
            return newList; 
        }
    }
}