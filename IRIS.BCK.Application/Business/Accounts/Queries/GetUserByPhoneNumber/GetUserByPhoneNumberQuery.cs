using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetUserByPhoneNumber
{
    public class GetUserByPhoneNumberQuery : IRequest<UserViewModel>
    {
        public string PhoneNumber { get; set; }

        public GetUserByPhoneNumberQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}