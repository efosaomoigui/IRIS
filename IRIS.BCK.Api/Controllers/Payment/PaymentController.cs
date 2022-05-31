using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePaymentLog;
using IRIS.BCK.Core.Application.Business.Payments.Commands.DeletePayment;
using IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByInvoiceCode;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentLog;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Payment
{
    public class PaymentController : BaseApiController
    {
        [HttpGet("Invoice/all", Name = "GetAllInvoice")]
        public async Task<ActionResult<List<PaymentListViewModel>>> GetAllInvoice()
        {
            var payments = await _mediator.Send(new GetPaymentQuery());
            return Ok(payments);
        }

        [HttpGet("Invoice/userInvoice", Name = "GetUserInvoice")]
        public async Task<ActionResult<List<PaymentListViewModel>>> GetUserInvoice() 
        {
            var userId = GetUserId();
            var payments = await _mediator.Send(new GetUserPaymentQuery(userId)); 
            return Ok(payments);
        }


        [HttpGet("GetInvoiceByInvoiceId/{invoiceid}")]
        public async Task<ActionResult<PaymentViewModel>> GetInvoiceByInvoiceId([FromRoute] Guid invoiceid)
        {
            var invoice = new PaymentViewModel();

            if (invoiceid != null)
            {
                invoice = await _mediator.Send(new GetPaymentByIdQuery(invoiceid.ToString()));
            }

            return Ok(invoice);
        }

        [HttpGet("GetInvoiceByInvoiceCode/{invoicecode}")]
        public async Task<ActionResult<ShipmentViewModel>> GetInvoiceByInvoiceCode([FromRoute] string invoicecode)
      {
            var invoice = new ShipmentViewModel();

            if (invoicecode != null)
            {
                invoice = await _mediator.Send(new GetPaymentByInvoiceCodeQuery(invoicecode.ToString())); 
            }

            return Ok(invoice);
        }

        //[HttpGet("GetInvoiceByUserId/{userid}")]
        //public async Task<ActionResult<PaymentViewModel>> GetInvoiceByUserId([FromRoute] Guid userid)
        //{
        //    var user = new PaymentViewModel();

        //    if (userid != null)
        //    {
        //        user = await _mediator.Send(new GetPaymentByUserIdQuery(userid.ToString()));
        //    }

        //    return Ok(user);
        //}

        [HttpPost("Invoice", Name = "AddInvoice")]
        public async Task<ActionResult<CreatePaymentCommandResponse>> Create([FromBody] CreatePaymentCommand createPaymentCommand)
        {
            var response = await _mediator.Send(createPaymentCommand);
            return Ok(response);
        }

        [HttpPut("Invoice/edit", Name = "UpdateInvoice")]
        public async Task<ActionResult<CreatePaymentCommandResponse>> UpdateInvoice([FromBody] UpdatePaymentCommand updatePaymentCommand)
        {
            var response = await _mediator.Send(updatePaymentCommand);
            return Ok(response);
        }

        [HttpDelete("Invoice/delete", Name = "DeleteInvoice")]
        public async Task<ActionResult<DeletePaymentCommandResponse>> DeleteInvoice([FromBody] DeletePaymentCommand deletePaymentCommand)
        {
            var response = await _mediator.Send(deletePaymentCommand);
            return Ok(response);
        }

        [HttpPost("Payment/MakePayment", Name = "MakePayment")]
        public async Task<ActionResult<PaymentCriteriaCommandResponse>> MakePayment([FromBody] PaymentCriteriaCommand createPriceCommand)
        {
            var response = await _mediator.Send(createPriceCommand);
            return Ok(response);
        }
                
        [HttpPost("Payment/UpdatePendingPayment", Name = "UpdatePendingPayment")]  
        public async Task<ActionResult<PaymentCriteriaCommandResponse>> UpdatePendingPayment([FromBody] UpdatePaymentPendingCommand updatePriceCommand)
        {
            var response = await _mediator.Send(updatePriceCommand);
            return Ok(response);
        }

        [HttpPost("PaymentLog", Name = "AddPaymentLog")]
        public async Task<ActionResult<CreatePaymentLogCommandResponse>> CreatePaymentLog([FromBody] CreatePaymentLogCommand createPaymentLogCommand)
        {
            var response = await _mediator.Send(createPaymentLogCommand);
            return Ok(response);
        }

        [HttpGet("PaymentLog/all", Name = "GetAllPaymentLog")]
        public async Task<ActionResult<List<PaymentLogViewModel>>> GetAllPaymentLog()
        {
            var paymentLogs = await _mediator.Send(new GetPaymentLogQuery());
            return Ok(paymentLogs);
        }
    }
}