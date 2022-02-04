using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Account;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole 
{

    public class CreateUserRoleCommandResponse : BaseResponse
    {
        public CreateUserRoleCommandResponse() : base()  
        {

        }

        public UserRoleDto roledto { get; set; }  
    }
}