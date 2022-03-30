using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetClaimForRole
{
    public class ListClaimsTypesQuery : IRequest<List<ClaimTypesViewModel>> 
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}