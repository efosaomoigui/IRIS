﻿using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumberCommand;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletById;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletByWalletNumberQuery;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByUserId;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Wallet
{
    public class WalletController : BaseApiController
    {
        [HttpGet("WalletNumber/all", Name = "GetAllWalletNumber")]
        public async Task<ActionResult<List<WalletNumberViewModel>>> GetAllWalletNumber()
        {
            var walletNumber = await _mediator.Send(new GetWalletNumberQuery());
            return Ok(walletNumber);
        }

        [HttpGet("GetWalletById/{walletid}")]
        public async Task<ActionResult<WalletViewModel>> GetWalletById([FromRoute] Guid walletid)
        {
            var wallet = new WalletViewModel();
            wallet = await _mediator.Send(new GetWalletByIdQuery(walletid.ToString()));
            return Ok(wallet);
        }

        [HttpGet("Wallets/GetWalletByAccountNumber/{accountnumber}")]
        public async Task<ActionResult<List<WalletNumberViewModel>>> GetWalletByAccountNumber(string accountnumber)
        {
            var wallet = await _mediator.Send(new GetWalletNumberQuery());
            return Ok(wallet);
        }

        [HttpPost("WalletNumber", Name = "AddWalletNumber")]
        public async Task<ActionResult<CreateWalletNumberCommandResponse>> Create([FromBody] CreateWalletNumberCommand createWalletNumberCommand)
        {
            var response = await _mediator.Send(createWalletNumberCommand);
            return Ok(response);
        }

        [HttpGet("WalletTransaction/all", Name = "GetAllWalletTransaction")]
        public async Task<ActionResult<List<WalletTransactionViewModel>>> GetAllWalletTransaction()
        {
            var walletTransaction = await _mediator.Send(new GetWalletTransactionQuery());
            return Ok(walletTransaction);
        }

        [HttpGet("WalletTransaction/GetWalletTransactionById/{transactionid}")]
        public async Task<ActionResult<List<WalletTransactionViewModel>>> GetTransactionByTransactionId(string transactionid)
        {
            var transaction = await _mediator.Send(new GetWalletTransactionQuery());
            return Ok(transaction);
        }

        [HttpGet("GetWalletTransactionByUserId/{userid}")]
        public async Task<ActionResult<List<WalletTransactionViewModel>>> GetWalletTransactionByUserId([FromRoute] Guid userid)
        {
            var walletTransactions = new List<WalletTransactionViewModel>();
            walletTransactions = await _mediator.Send(new GetWalletTransactionByUserIdQuery(userid.ToString()));
            return Ok(walletTransactions);
        }

        [HttpPost("WalletTransaction", Name = "AddWalletTransaction")]
        public async Task<ActionResult<CreateWalletTransactionCommandResponse>> Create([FromBody] CreateWalletTransactionCommand createWalletTransactionCommand)
        {
            var response = await _mediator.Send(createWalletTransactionCommand);
            return Ok(response);
        }
    }
}