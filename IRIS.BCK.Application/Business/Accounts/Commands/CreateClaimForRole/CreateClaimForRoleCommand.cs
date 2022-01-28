using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateClaimForRole
{ 
    public class CreateClaimForRoleCommand : IRequest<CreateClaimForRoleCommandResponse>
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; } 
        public string ClaimValue { get; set; } 
    } 
}
