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
        public string Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; }
        public WalletNumber WalletNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
    }
}