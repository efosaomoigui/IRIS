using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Account;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser
{

    public class CreateRoleCommandResponse : BaseResponse
    {
        public CreateRoleCommandResponse() : base() 
        {

        }

        public RoleDto roledto { get; set; } 
    }
}