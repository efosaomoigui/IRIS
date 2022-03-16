using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole  
{ 
    public class CreateUserRoleCommand : IRequest<CreateUserRoleCommandResponse>  
    {
        public string UserId { get; set; }
        public string[] RoleId { get; set; }  
    }  
}
