using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
 
namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList
{
    class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListViewModel>>
    {
        private readonly IGenericRepository<User> _userRepository; 
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allShiments = (await _userRepository.GetAllAsync()).OrderBy(x => x.DateCreated);
            return _mapper.Map<List<UserListViewModel>>(allShiments);
        }
    }
}
