using IRIS.BCK.Core.Application.Interfaces.IRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Wallets
{
    public class WalletRepository : GenericRepository<WalletNumber>, IWalletRepository
    {
        public WalletRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckUniqueWalletNumber(string walletNumber)
        {
            return true;
        }
    }
}