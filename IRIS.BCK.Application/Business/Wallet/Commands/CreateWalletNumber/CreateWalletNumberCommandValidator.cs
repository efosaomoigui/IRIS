using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber
{
    public class CreateWalletNumberCommandValidator : AbstractValidator<CreateWalletNumberCommand>
    {
        public IWalletRepository _walletRepository { get; set; }

        public CreateWalletNumberCommandValidator(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;

            RuleFor(p => p.IsActive)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Number)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            //RuleFor(p => p.UserId)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull();
        }
    }
}