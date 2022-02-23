using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
using IRIS.BCK.Core.Application.Business.Payments.Commands.DeletePayment;
using IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment;
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
        [HttpGet("Payment/all", Name = "GetAllPayments")]
        public async Task<ActionResult<List<PaymentListViewModel>>> GetAllShipments()
        {
            var payments = await _mediator.Send(new GetPaymentQuery());
            return Ok(payments);
        }

        [HttpGet("Invoice/GetInvoiceByInvoiceCode/{invoicecode}")]
        public async Task<ActionResult<List<PaymentListViewModel>>> GetInvoiceByInvoiceCode(string invoicecode)
        {
            var code = await _mediator.Send(new GetPaymentQuery());
            return Ok(code);
        }

        [HttpGet("Invoice/GetInvoiceByInvoiceId/{invoiceid}")]
        public async Task<ActionResult<List<PaymentListViewModel>>> GetInvoiceByInvoiceId(string invoiceid)
        {
            var invoice = await _mediator.Send(new GetPaymentQuery());
            return Ok(invoice);
        }

        [HttpPost("Payment", Name = "AddPayment")]
        public async Task<ActionResult<CreatePaymentCommandResponse>> Create([FromBody] CreatePaymentCommand createPaymentCommand)
        {
            var response = await _mediator.Send(createPaymentCommand);
            return Ok(response);
        }

        [HttpPut("Payment/edit", Name = "UpdatePayment")]
        public async Task<ActionResult<CreatePaymentCommandResponse>> UpdateShipment([FromBody] UpdatePaymentCommand updatePaymentCommand)
        {
            var response = await _mediator.Send(updatePaymentCommand);
            return Ok(response);
        }

        [HttpDelete("Payment/delete", Name = "DeletePayment")]
        public async Task<ActionResult<DeletePaymentCommandResponse>> DeleteShipment([FromBody] DeletePaymentCommand deletePaymentCommand)
        {
            var response = await _mediator.Send(deletePaymentCommand);
            return Ok(response);
        }
    }
}