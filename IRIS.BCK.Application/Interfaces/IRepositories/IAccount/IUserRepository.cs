using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> CheckPasswordRequirement(string password, CancellationToken token);
        Task<User> GetUserWithCredentials(string username, string password);
    }

    public interface IRoleClaimRepository : IGenericRepository<AppRoleClaim> 
    {
        Task<List<AppRoleClaim>> GetAllClaims(); 
    }
}
