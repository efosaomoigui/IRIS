using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IWalletRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand
{
    public class CreateWalletTransactionCommandValidator : AbstractValidator<CreateWalletTransactionCommand>
    {
        public IWalletTransactionRepository _walletTransactionRepository { get; set; }

        public CreateWalletTransactionCommandValidator(IWalletTransactionRepository walletTransactionRepository)
        {
            _walletTransactionRepository = walletTransactionRepository;

            RuleFor(p => p.WalletNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.TransactionType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}