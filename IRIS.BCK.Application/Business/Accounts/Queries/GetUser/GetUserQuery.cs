using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList
{
    public class GetUserQuery : IRequest<UserViewModel>  
    {

        public Guid UserId { get; set; }
        public int Id { get; set; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
