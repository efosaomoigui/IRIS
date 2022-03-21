using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<UserViewModel>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}