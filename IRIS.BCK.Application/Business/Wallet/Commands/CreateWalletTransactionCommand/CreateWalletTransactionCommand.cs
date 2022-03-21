﻿using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand
{
    public class CreateWalletTransactionCommand : IRequest<CreateWalletTransactionCommandResponse>
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; }

        // public string WalletNumber { get; set; }
        public Guid UserId { get; set; }
    }
}