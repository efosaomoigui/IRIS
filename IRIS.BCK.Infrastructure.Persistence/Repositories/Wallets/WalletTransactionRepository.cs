using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Wallets
{
    public class WalletTransactionRepository : GenericRepository<WalletTransaction>, IWalletTransactionRepository
    {
        private IGenericRepository<WalletNumber> _walletRepository { get; set; }

        private IWalletTransactionRepository _walletTransactionRepository { get; set; }
        public WalletTransactionRepository(IRISDbContext dbContext, IGenericRepository<WalletNumber> walletRepository) : base(dbContext)
        {
            _walletRepository = walletRepository;
            //_walletTransactionRepository = walletTransactionRepository;
        }

        public Task<bool> CheckUniqueWalletTransactionNumber(string walletTransaction)
        {
            throw new NotImplementedException();
        }

        public async Task<WalletTransaction> GetWalletTransactionByUserId(string userid)
        {
            return _dbContext.WalletTransaction.FirstOrDefault(e => e.UserId.ToString() == userid);
        }

        public async Task<WalletTransaction> WalletCredit(WalletTransaction walletTransaction)
        {
            //get the wallet balance
            var wallet = _dbContext.WalletNumber.FirstOrDefault(x => x.UserId == walletTransaction.UserId);
            var walletBalance = wallet.WalletBalance;

            //Credit wallet balance if
            //balance greater than wallettransaction.amount
            if (walletBalance > (decimal)(walletTransaction.Amount))
            {
                var newWalletBalane = walletBalance + (decimal)walletTransaction.Amount;
                await _dbContext.WalletTransaction.AddAsync(walletTransaction);
                wallet.WalletBalance = newWalletBalane;
                wallet.UserId = walletTransaction.UserId;
                await _walletRepository.UpdateAsync(wallet);
                return walletTransaction;
            }

            //return null if not possible
            return null;
        }

        public async Task<WalletTransaction> WalletDebit(WalletTransaction walletTransaction) 
        {
            //get the wallet balance
            var wallet =  _dbContext.WalletNumber.FirstOrDefault(x => x.UserId == walletTransaction.UserId);
            var walletBalance = wallet.WalletBalance; 

            //debit wallet balance if
            //balance greater than wallettransaction.amount
            if (walletBalance > (decimal)(walletTransaction.Amount))
            {
                var newWalletBalane = walletBalance - (decimal)walletTransaction.Amount ;
                await _dbContext.WalletTransaction.AddAsync(walletTransaction);
                wallet.WalletBalance = newWalletBalane;
                wallet.UserId = walletTransaction.UserId;
                await _walletRepository.UpdateAsync(wallet);
                return walletTransaction;
            }

            //return null if not possible
            return null;
        }
    }
}