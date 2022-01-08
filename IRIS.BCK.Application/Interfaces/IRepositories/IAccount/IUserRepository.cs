using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.AccountEntities;
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
    }
}
