using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private IUserRepository _userRepository;

        public UpdateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Password) // Custom Validation for unique waybills
                .MustAsync(_userRepository.CheckPasswordRequirement).WithMessage("{PropertyName} must be unique");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}