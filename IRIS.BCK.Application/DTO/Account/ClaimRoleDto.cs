using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Account
{
    public class ClaimRoleDto 
    {
        public AppRole Role { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
