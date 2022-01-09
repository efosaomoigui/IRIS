using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IRIS.BCK.Core.Domain.Entities.AccountEntities
{
    public class User : IdentityUser<string>
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
        public string WalletAddress { get; set; }

    }
}
