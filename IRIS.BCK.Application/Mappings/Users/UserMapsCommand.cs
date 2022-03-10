using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateClaimForRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Users
{
    public static class UserMapsCommand
    {
        public static User CreateUserMapsCommand(CreateUserCommand request)
        {
            return new User
            {
                UserId = request.Id,
                UserName = request.Username,
                Password = request.Password,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Age = request.Age,
                Designation = request.Designation,
                Department = request.Department,
                PictureUrl = request.PictureUrl,
                IsActive = request.IsActive,
                Organisation = request.Organisation,
                Status = request.Status,
                DateCreated = request.DateCreated,
                DateModified = request.DateModified,
                SystemUserId = request.SystemUserId,
                SystemUserRole = request.SystemUserRole,
                PasswordExpireDate = request.PasswordExpireDate,
                IdentificationImage = request.IdentificationImage,
                WalletNumber = request.WalletNumber
            };
        }

        public static User UpdateUserMapsCommand(UpdateUserCommand request)
        {
            return new User
            {
                UserId = request.Id,
                UserName = request.Username,
                Password = request.Password,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Age = request.Age,
                Designation = request.Designation,
                Department = request.Department,
                PictureUrl = request.PictureUrl,
                IsActive = request.IsActive,
                Organisation = request.Organisation,
                Status = request.Status,
                DateCreated = request.DateCreated,
                DateModified = request.DateModified,
                SystemUserId = request.SystemUserId,
                SystemUserRole = request.SystemUserRole,
                PasswordExpireDate = request.PasswordExpireDate,
                IdentificationImage = request.IdentificationImage,
                WalletNumber = request.WalletNumber
            };
        }

        public static AppRole CreateRoleMapsCommand(CreateRoleCommand request)
        {
            return new AppRole
            {
                Name = request.Name
            };
        }

        public static AppRoleClaim CreateClaimForRoleMapsCommand(CreateClaimForRoleCommand request)
        {
            return new AppRoleClaim
            {
                RoleId = request.RoleId,
                ClaimType = request.ClaimType,
                ClaimValue = request.ClaimValue,
            };
        }

        public static Email CreateUserEmailMessage(string to, string body, string subject)
        {
            return new Email
            {
                To = to,
                Body = body,
                Subject = subject
            };
        }

        public static AppUserRole CreateUserRoleMapsCommand(CreateUserRoleCommand request)
        {
            return new AppUserRole
            {
                UserId = request.UserId,
                RoleId = request.RoleName
            };
        }
    }
}