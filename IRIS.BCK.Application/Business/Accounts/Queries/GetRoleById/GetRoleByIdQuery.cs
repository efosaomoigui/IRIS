using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles 
{
    public class GetRoleByIdQuery : IRequest<RoleByIdViewModel> 
    {
        public string id { get; set; }
        public GetRoleByIdQuery(string roleId)
        {
            id = roleId;
        }
    }
}
