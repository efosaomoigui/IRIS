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
    class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleByIdViewModel>
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public GetRoleByIdQueryHandler(IMapper mapper, RoleManager<AppRole> roleManager) 
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<RoleByIdViewModel> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var roleResult = (_roleManager.Roles.ToList()).FirstOrDefault(x => x.Id == request.id);
            return _mapper.Map<RoleByIdViewModel>(roleResult);
        }
    }
}
