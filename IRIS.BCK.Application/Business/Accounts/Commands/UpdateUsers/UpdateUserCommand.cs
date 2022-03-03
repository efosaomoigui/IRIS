using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string PictureUrl { get; set; }
        public bool IsActive { get; set; }
        public string Organisation { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }

        //for system user
        public string SystemUserId { get; set; }

        public string SystemUserRole { get; set; }
        public DateTime PasswordExpireDate { get; set; }

        //User Active CountryId
        public string IdentificationImage { get; set; }

        public string WalletNumber { get; set; }
    }
}