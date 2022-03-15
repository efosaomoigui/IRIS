using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using  IRIS.BCK.Core.Domain.EntityEnums;

namespace IRIS.BCK.Core.Application.Business.Accounts.AccountEntities
{
    public class User : IdentityUser
    {
        [Key]
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Organisation { get; set; }
        public UserType UserType { get; set; }
        public string PictureUrl { get; set; }
        public string IdentificationImage { get; set; }
        public UserStatus Status { get; set; }
        public string WalletNumber { get; set; }
        public DateTime PasswordExpireDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

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
    }

    public class AppUserRole : IdentityUserRole<string>
    {
        public AppUserRole() : base() { }
    }

    public class AppRoleClaim : IdentityRoleClaim<string>
    {
        public AppRoleClaim() : base() { } 
    }
}
