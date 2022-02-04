using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private IUserRepository _userRepository;

        public CreateUserCommandValidator(IUserRepository userRepository)
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