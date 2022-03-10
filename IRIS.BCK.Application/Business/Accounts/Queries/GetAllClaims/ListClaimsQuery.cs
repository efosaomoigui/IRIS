using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetClaimForRole
{
    public class ListClaimsQuery : IRequest<List<ListClaimViewModel>> 
    {
        public Guid RoleId { get; set; }
        public Guid Id { get; set; }
    }
}