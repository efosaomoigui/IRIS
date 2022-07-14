using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.ServiceCentre.Queries.GetServiceCenter;
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
        private IMediator _mediator;

        public GetUserQueryHandler(IGenericRepository<User> userRepository, IMapper mapper, UserManager<User> userManager, IMediator mediator = null)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            //var user = (await _userRepository.GetByUserIdAsync(request.UserId));
            var userid = request.Id.ToString(); 
            var user = await _userManager.FindByIdAsync(userid);
            var roleexist = _userManager.GetRolesAsync(user).Result.ToList();
            var scexist = _userManager.GetClaimsAsync(user).Result.ToList();

            var serviceCenters = await _mediator.Send(new GetServiceCenterJsonQuery()); 

            var result =  _mapper.Map<UserViewModel>(user);
            result.Roles = roleexist;
            result.ServiceCenters = scexist.Select(s => s.Value).ToList();
            var scNames = new StringBuilder();

            foreach (var code in result.ServiceCenters)
            {
                var name = serviceCenters.Where(s => s.Code == code).FirstOrDefault();
                scNames.Append("/");
                scNames.Append(name.Terminals);
            }

            result.ServiceCenterNames = scNames.ToString();

            return result;
        }
    }
}
