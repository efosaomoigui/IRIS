using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers
{
    public class UpdateUserCommandResponse : BaseResponse
    {
        public UpdateUserCommandResponse() : base()
        {
        }

        public UserDto Userdto { get; set; }
    }
}