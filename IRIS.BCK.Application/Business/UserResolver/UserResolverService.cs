using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.UserResolver
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<User> _userManager;
        public UserResolverService(IHttpContextAccessor context, UserManager<User> userManager = null)
        {
            _context = context;
            _userManager = userManager;
        }

        public string GetUser() 
        {
            var userName = _context.HttpContext.User?.Identity?.Name;
            var userExist = _userManager.FindByNameAsync(userName).Result;
            return userExist.UserId.ToString();
        }
    }
}
