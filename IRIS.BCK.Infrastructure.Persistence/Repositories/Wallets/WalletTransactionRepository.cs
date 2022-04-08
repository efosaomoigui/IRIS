using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<WalletNumber>> GetWalletTransactionByUserId(string userid)
        {
            var result = await _dbContext.WalletNumber.Where(e => e.UserId.ToString() == userid).OrderByDescending(e => e.Id).Include(s => s.WalletTransactions).ToListAsync();
            //var result =  _dbContext.WalletTransaction.Where(e => e.UserId.ToString() == userid).ToList();
            return result;
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
                walletTransaction.WalletNumberId = wallet.Id;
                walletTransaction.TransactionType = TransactionType.Credit;
                walletTransaction.LineBalance = newWalletBalane;
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
                walletTransaction.WalletNumberId = wallet.Id;
                walletTransaction.TransactionType = TransactionType.Debit;
                walletTransaction.LineBalance = newWalletBalane;
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