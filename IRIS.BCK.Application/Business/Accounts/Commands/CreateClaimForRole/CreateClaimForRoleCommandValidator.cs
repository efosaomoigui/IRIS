using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateClaimForRole
{
    public class CreateClaimForRoleCommandValidator : AbstractValidator<CreateClaimForRoleCommand>
    {
        private IUserRepository _userRepository;

        public CreateClaimForRoleCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.RoleId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

                    RuleFor(p => p.ClaimType)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

                    RuleFor(p => p.ClaimValue)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();
        }


    }
}
