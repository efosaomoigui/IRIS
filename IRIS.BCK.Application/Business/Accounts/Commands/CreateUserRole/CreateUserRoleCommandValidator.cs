using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUserRole 
{
    public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        private IUserRepository _userRepository;

        public CreateUserRoleCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }


    }
}
