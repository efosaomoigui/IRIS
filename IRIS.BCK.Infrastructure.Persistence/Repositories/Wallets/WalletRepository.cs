using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Interfaces.IRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.INumberEntRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using IRIS.BCK.Core.Domain.Entities.NumberEnt;
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
    public class WalletRepository : GenericRepository<WalletNumber>, IWalletRepository
    {
        private INumberEntRepository _numberEntRepository;

        public WalletRepository(IRISDbContext dbContext, INumberEntRepository numberEntRepository) : base(dbContext)
        {
            _numberEntRepository = numberEntRepository;
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

        public string GetWalletNumber(string serviceCenterCode)
        {
            var str = _numberEntRepository.GenerateNextNumber(NumberGeneratorType.WalletNumber, serviceCenterCode).Result ;
            return str;
        }

        public Task<WalletNumber> GetWalletById(string walletid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DashboardShipmentListViewModel>> GetDashboardWalletsTransaAndNumbers()
        {
            var lsShipments = await _dbContext.WalletTransaction.GroupBy(x => new { x.CreatedDate.Month }).OrderBy(g => g.Key.Month)
                .Select(g => new DashboardShipmentListViewModel
                {
                    Month = g.Key.Month.ToString(),
                    MonthData = g.Sum(y => y.Amount)
                }).ToListAsync();

            return lsShipments;
        }

        public async Task<List<DashboardShipmentListViewModel>> GetUserDashboardWalletsTransaAndNumbers(string userId) 
        {
            var lsShipments = await _dbContext.WalletTransaction.Where(p => p.UserId== new Guid(userId)).GroupBy(x => new { x.CreatedDate.Month }).OrderBy(g => g.Key.Month)
                .Select(g => new DashboardShipmentListViewModel
                {
                    Month = g.Key.Month.ToString(),
                    MonthData = g.Sum(y => y.Amount)
                }).ToListAsync();

            return lsShipments;
        }

        public async Task<List<WalletNumber>> GetWalletsTransaAndNumbers()
        {
            var lsWallets = await _dbContext.WalletNumber.Include(s => s.WalletTransactions).ToListAsync();
            return lsWallets;
        }

        public async Task<List<WalletNumber>> GetWalletTransactionByWalletNumber(string walletNumber)
        {
            var result = await _dbContext.WalletNumber.Where(e => e.Number == walletNumber).OrderByDescending(e => e.Id).Include(s => s.WalletTransactions).ToListAsync();
            return result;
        }
    }
}