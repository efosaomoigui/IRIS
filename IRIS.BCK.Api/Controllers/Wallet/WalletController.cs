using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber;
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

        [HttpGet("Wallets/GetWalletByWalletNumber/{walletnumber}")]
        public async Task<ActionResult<List<WalletTransactionAndTotalViewModel>>> GetWalletByAccountNumber(string walletnumber) 
        {
            var wallet = await _mediator.Send(new GetWalletTransactionByWalletNumberQuery(walletnumber));
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

        [HttpGet("WalletTransaction/dashboard", Name = "GetDashboardWalletTransaction")]
        public async Task<ActionResult<List<WalletTransactionViewModel>>> GetDashboardWalletTransaction() 
        {
            var walletTransaction = await _mediator.Send(new GetDashboardWalletTransactionQuery());
            return Ok(walletTransaction);
        }


        [HttpGet("WalletTransaction/userDashboard", Name = "GetUserDashboardWalletTransaction")]
        public async Task<ActionResult<List<WalletTransactionViewModel>>> GetUserDashboardWalletTransaction()
        {
            var userid = GetUserId();
            var walletTransaction = await _mediator.Send(new GetUserDashboardWalletTransactionQuery(userid));
            return Ok(walletTransaction);
        }

        [HttpGet("WalletTransaction/GetWalletTransactionById/{transactionid}")]
        public async Task<ActionResult<List<DashboardShipmentListViewModel>>> GetTransactionByTransactionId(string transactionid)
        {
            var transaction = await _mediator.Send(new GetWalletTransactionQuery());
            return Ok(transaction);
        }

        [HttpGet("GetWalletTransactionByUserId")]
        public async Task<ActionResult<List<WalletTransactionViewModel>>> GetWalletTransactionByUserId()
        {
            var userId = GetUserId();
            var walletTransactions = new List<WalletTransactionViewModel>();
            walletTransactions = await _mediator.Send(new GetWalletTransactionByUserIdQuery(userId));
            return Ok(walletTransactions);
        }

        [HttpPost("WalletTransaction", Name = "AddWalletTransaction")]
        public async Task<ActionResult<CreateWalletTransactionCommandResponse>> Create([FromBody] CreateWalletTransactionCommand createWalletTransactionCommand)
        {
            var response = await _mediator.Send(createWalletTransactionCommand);
            return Ok(response);
        }

        [HttpPost("CreditWallet", Name = "CreditWallet")]
        public async Task<ActionResult<CreateWalletTransactionCommandResponse>> CreditWallet([FromBody] CreditWalletCommand creditWalletCommand)
        {
            var response = await _mediator.Send(creditWalletCommand);
            return Ok(response);
        }

        [HttpPost("DebitWallet", Name = "DebitWallet")]
        public async Task<ActionResult<CreateWalletTransactionCommandResponse>> DebitWallet([FromBody] DebitWalletCommand debitWalletCommand) 
        {
            var response = await _mediator.Send(debitWalletCommand); 
            return Ok(response);
        }
    }
}