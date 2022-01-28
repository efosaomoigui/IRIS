using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList
{
    class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, List<RoleListViewModel>>
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public GetRoleListQueryHandler(IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<List<RoleListViewModel>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roleResult = (_roleManager.Roles.ToList()).OrderBy(x => x.Name).ToList();
            var allRoles = _mapper.Map<List<RoleListViewModel>>(roleResult);
            return _mapper.Map<List<RoleListViewModel>>(allRoles);
        }
    }
}
