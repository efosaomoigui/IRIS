using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using IRIS.BCK.Core.Domain.EntityEnums;
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
    public class ListClaimsTypesQueryHandler : IRequestHandler<ListClaimsTypesQuery, List<ClaimTypesViewModel>>  
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IRoleClaimRepository _roleClaimRepository;   
        private readonly RoleManager<AppRole> _roleManager;

        public ListClaimsTypesQueryHandler(IMapper mapper, IEmailService emailService, RoleManager<AppRole> roleManager,
            IRoleClaimRepository roleClaimRepository)
        {
            _mapper = mapper;
            _emailService = emailService;
            _roleManager = roleManager;
            _roleClaimRepository = roleClaimRepository;
        }

        public async Task<List<ClaimTypesViewModel>> Handle(ListClaimsTypesQuery request, CancellationToken cancellationToken)
        {
            var claimTypes = new List<ClaimTypesViewModel>(); 
            var listtypes = Enum.GetValues(typeof(ClaimTypes))  
                            .Cast<ClaimTypes>()
                            .ToList();

            foreach (var listType in listtypes) 
            {
                claimTypes.Add(new ClaimTypesViewModel { 
                    ClaimType = listType.ToString(),
                    ClaimValue = listType.ToString(),
                });
            }

            return claimTypes;
        }
    }
}