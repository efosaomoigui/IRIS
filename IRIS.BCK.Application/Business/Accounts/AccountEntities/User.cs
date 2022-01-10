using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IRIS.BCK.Core.Application.Business.Accounts.AccountEntities
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
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
        public int WalletNumber { get; set; } 

    }

    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class AppUserClaim : IdentityUserClaim<string>
    {
        public AppUserClaim() : base() { }
        public string SystemRoleId { get; set; }
    }
}
