using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Account;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateAuthCredentials
{
    internal class CreateAuthCredentialsCommandResponse : BaseResponse
    {
        public CreateAuthCredentialsCommandResponse() : base()
        {

        }

        public AuthResponseDto authresponsedto { get; set; } 
    }
}