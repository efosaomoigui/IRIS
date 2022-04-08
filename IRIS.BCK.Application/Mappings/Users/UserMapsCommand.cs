using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateClaimForRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Domain.EntityEnums;
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
                PictureUrl = request.PictureUrl,
                Organisation = request.Organisation,
                Status = request.Status,
                DateCreated = request.DateCreated,
                DateModified = request.DateModified,
                PasswordExpireDate = request.PasswordExpireDate,
                IdentificationImage = request.IdentificationImage,
                WalletNumber = request.WalletNumber
            };
        }

        public static string RandomDigits(int length)
        {

                // creating a StringBuilder object()
                StringBuilder str_build = new StringBuilder();
                Random random = new Random();

                char letter;

                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);
                }

                return str_build.ToString();
        }

        public static CreateUserCommand CreateShipperMapsCommand(Values request) 
        {
            var name = request.shipperFullName.Split(' ');
            return new CreateUserCommand
            {
                UserId = new Guid(),
                Username = RandomDigits(7),
                Password = "Iris12345#",
                FirstName = name[0],
                LastName = (name.Length > 1)? name[1]: name[0],
                PhoneNumber = request.shipperPhoneNumber.ToString(),
            };
        }

        public static CreateUserCommand CreateReceiverMapsCommand(Values request)
        {
            var name = request.receiverFullName.Split(' '); 
            return new CreateUserCommand
            {
                UserId = new Guid(),
                Username = RandomDigits(7),
                Password = "Iris12345#",
                FirstName = name[0],
                LastName = (name.Length > 1) ? name[1] : name[0],
                PhoneNumber = request.receiverPhoneNumber.ToString(),
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
                PictureUrl = request.PictureUrl,
                Organisation = request.Organisation,
                DateCreated = request.DateCreated,
                DateModified = request.DateModified,
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
            };
        }
    }
}