﻿using IRIS.BCK.Core.Application.Interfaces.IRepositories;
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

        public string GetWalletNumber()
        {
            string s = "0000000001";
            int num = Convert.ToInt32(s);
            num += 1;
            string str = num.ToString("D10");

            return str;
        }
    }
}