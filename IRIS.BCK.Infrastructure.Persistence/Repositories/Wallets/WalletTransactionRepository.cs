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
        public WalletTransactionRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> CheckUniqueWalletTransactionNumber(string walletTransaction)
        {
            throw new NotImplementedException();
        }
    }
}