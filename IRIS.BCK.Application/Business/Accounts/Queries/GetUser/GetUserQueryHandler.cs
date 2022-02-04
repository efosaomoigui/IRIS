using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
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
    class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IGenericRepository<User> _userRepository; 
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserQueryHandler(IGenericRepository<User> userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //var user = (await _userRepository.GetByUserIdAsync(request.UserId));
            var userid = request.Id.ToString(); 
            var user = await _userManager.FindByIdAsync(userid);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
