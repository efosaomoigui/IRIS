using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserViewModel>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserByEmailQueryHandler(IGenericRepository<User> userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserViewModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var email = (_userManager.Users.ToList()).FirstOrDefault(x => x.Email == request.Email);
            return _mapper.Map<UserViewModel>(email);
        }
    }
}