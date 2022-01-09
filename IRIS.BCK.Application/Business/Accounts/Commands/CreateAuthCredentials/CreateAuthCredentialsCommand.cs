using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateAuthCredentials
{
    public class CreateAuthCredentialsCommand : IRequest<CreateAuthCredentialsCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
