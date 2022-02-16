using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories
{
    public interface IWalletRepository : IGenericRepository<WalletNumber>
    {
        Task<bool> CheckUniqueWalletNumber(string walletNumber);
        Task<bool> GetLastWalletNumber(); 
    }
}