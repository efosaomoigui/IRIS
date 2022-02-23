﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetClaimForRole
{
    public class GetClaimForRoleQuery : IRequest<ClaimViewModel>
    {
        public Guid RoleId { get; set; }
        public Guid Id { get; set; }

        public GetClaimForRoleQuery(string roleid)
        {
            Guid RoleGuid = new Guid(roleid);
            RoleId = RoleGuid;
            Id = RoleGuid;
        }
    }
}