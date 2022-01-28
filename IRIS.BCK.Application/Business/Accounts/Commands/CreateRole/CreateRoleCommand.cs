using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateRole
{ 
    public class CreateRoleCommand : IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
    } 
}
