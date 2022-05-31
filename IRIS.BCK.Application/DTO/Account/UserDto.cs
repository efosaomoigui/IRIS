using  IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Account
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public int Age { get; set; }
        public string PictureUrl { get; set; }
        public Gender Gender { get; set; } 
        public string Organisation { get; set; }
        public UserType UserType { get; set; } 
        public UserStatus Status { get; set; }
        public string IdentificationImage { get; set; }
        public string WalletNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime PasswordExpireDate { get; set; }
        public Boolean ConfirmEmail { get; set; } 

    }
}