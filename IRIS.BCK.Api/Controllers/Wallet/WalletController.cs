using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumberCommand;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletTransactionCommand;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletByWalletNumberQuery;
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

        [HttpGet("Wallets/GetWalletById/{walletid}")]
        public async Task<ActionResult<WalletNumberViewModel>> GetWalletById(string walletid)
        {
            var wallet = await _mediator.Send(new GetWalletNumberQuery());
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
        public async Task<ActionResult<List<WalletNumberViewModel>>> GetAllWalletTransaction()
        {
            var walletTransaction = await _mediator.Send(new GetWalletTransactionQuery());
            return Ok(walletTransaction);
        }

        [HttpGet("WalletTransaction/GetWalletTransactionById/{transactionid}")]
        public async Task<ActionResult<List<WalletNumberViewModel>>> GetTransactionByTransactionId(string transactionid)
        {
            var transaction = await _mediator.Send(new GetWalletTransactionQuery());
            return Ok(transaction);
        }

        [HttpPost("WalletTransaction", Name = "AddWalletTransaction")]
        public async Task<ActionResult<CreateWalletTransactionCommandResponse>> Create([FromBody] CreateWalletTransactionCommand createWalletTransactionCommand)
        {
            var response = await _mediator.Send(createWalletTransactionCommand);
            return Ok(response);
        }
    }

    // Add wallet
    //1. Get User to create wallet for by using _userRepository
    //2. Generate wallet number. An algorithm.
    // (a). GetLastValue() from the walletNumbersHub
    // (b). Increment by 1
    // (c). Insert into walletNumberHub
    // (d). Hold in a variable for the user
    //3.
}