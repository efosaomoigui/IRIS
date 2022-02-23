using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetClaimForRole
{
    public class GetClaimForRoleQueryHandler : IRequestHandler<GetClaimForRoleQuery, ClaimViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IRoleClaimRepository _roleClaimRepository;
        private readonly RoleManager<AppRole> _roleManager;

        public GetClaimForRoleQueryHandler(IMapper mapper, IEmailService emailService, RoleManager<AppRole> roleManager,
            IRoleClaimRepository roleClaimRepository)
        {
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
            _roleClaimRepository = roleClaimRepository;
        }

        public async Task<ClaimViewModel> Handle(GetClaimForRoleQuery request, CancellationToken cancellationToken)
        {
            var roleid = request.Id.ToString();
            var role = await _roleManager.FindByIdAsync(roleid);

            return _mapper.Map<ClaimViewModel>(role);
        }
    }
}