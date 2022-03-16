﻿using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories
{
    public interface IWalletTransactionRepository : IGenericRepository<WalletTransaction>
    {
        Task<bool> CheckUniqueWalletTransactionNumber(string walletTransaction);

        Task<WalletTransaction> GetWalletTransactionByUserId(string userid);
    }
}