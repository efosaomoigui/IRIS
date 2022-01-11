using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Account;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser
{

    public class CreateUserCommandResponse : BaseResponse
    {
        public CreateUserCommandResponse() : base() 
        {

        } 

        public UserDto Userdto { get; set; }
    }
}