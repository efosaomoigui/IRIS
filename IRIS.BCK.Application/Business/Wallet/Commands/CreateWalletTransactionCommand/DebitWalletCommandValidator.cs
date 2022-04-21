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
    public class DebitWalletCommandValidator : AbstractValidator<DebitWalletCommand>
    {
        public IWalletTransactionRepository _walletTransactionRepository { get; set; }

        public DebitWalletCommandValidator(IWalletTransactionRepository walletTransactionRepository)
        { 
            _walletTransactionRepository = walletTransactionRepository;

            //RuleFor(p => p.WalletNumber)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull();

            RuleFor(p => p.TransactionType)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}