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

        public Task<int> GetWalletBalance(string User)
        {
            throw new NotImplementedException();
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        public string GetWalletNumber()
        {
            var str = RandomDigits(10);
            return str;
        }

        public Task<WalletNumber> GetWalletById(string walletid)
        {
            throw new NotImplementedException();
        }
    }
}