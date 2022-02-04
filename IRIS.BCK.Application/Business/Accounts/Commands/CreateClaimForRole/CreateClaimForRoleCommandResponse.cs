using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Account;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateClaimForRole 
{

    public class CreateClaimForRoleCommandResponse : BaseResponse
    {
        public CreateClaimForRoleCommandResponse() : base()  
        {

        }

        public ClaimRoleDto roledto { get; set; } 
    }
}