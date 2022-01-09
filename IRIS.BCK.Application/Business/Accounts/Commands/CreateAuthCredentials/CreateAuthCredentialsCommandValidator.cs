using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IAccount;

namespace IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateAuthCredentials
{
    public class CreateAuthCredentialsCommandValidator : AbstractValidator<CreateAuthCredentialsCommand>
    {
        private IUserRepository _userRepository;

        public CreateAuthCredentialsCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Password) // Custom Validation for unique waybills
                .MustAsync(_userRepository.CheckPasswordRequirement).WithMessage("{PropertyName} must be unique");
        }
    }
}