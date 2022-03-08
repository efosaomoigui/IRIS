using IRIS.BCK.Application.Interfaces.IRepository.IShipmentRepositories;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Persistence.Repositories.Accounts
{ 
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> CheckPasswordRequirement(string password, CancellationToken token)
        {
            //To be changed to implementation of proper password requirement
            return Task.FromResult(password.GetType() == typeof(string));
        }

        public async Task<User> GetUserWithCredentials(string username, string password)
        {
            var user = await GetAllAsync();
            var userresult = user.FirstOrDefault(s => s.UserName == username && s.Password == password);
            return userresult;
        }
    }

    public class RoleClaimRepository : GenericRepository<AppRoleClaim>, IRoleClaimRepository
    {
        public RoleClaimRepository(IRISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<AppRoleClaim>> GetAllClaims()
        {
            var claims = await GetAllAsync();
            return claims.ToList();
        }
    }
}
