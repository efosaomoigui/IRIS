using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
using IRIS.BCK.Core.Application.Business.Payments.Commands.DeletePayment;
using IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByUserId;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem;
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
        public async Task<ActionResult<List<PaymentListViewModel>>> GetAllPayments()
        {
            var payments = await _mediator.Send(new GetPaymentQuery());
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
        public async Task<ActionResult<PaymentViewModel>> GetInvoiceByInvoiceCode([FromRoute] string invoicecode)
        {
            var invoice = new PaymentViewModel();

            if (invoicecode != null)
            {
                invoice = await _mediator.Send(new GetPaymentByIdQuery(invoicecode.ToString()));
            }

            return Ok(invoice);
        }

        [HttpGet("GetInvoiceByUserId/{userid}")]
        public async Task<ActionResult<PaymentViewModel>> GetInvoiceByUserId([FromRoute] Guid userid)
        {
            var user = new PaymentViewModel();

            if (userid != null)
            {
                user = await _mediator.Send(new GetPaymentByUserIdQuery(userid.ToString()));
            }

            return Ok(user);
        }

        [HttpPost("Payment", Name = "AddPayment")]
        public async Task<ActionResult<CreatePaymentCommandResponse>> Create([FromBody] CreatePaymentCommand createPaymentCommand)
        {
            var response = await _mediator.Send(createPaymentCommand);
            return Ok(response);
        }

        [HttpPut("Payment/edit", Name = "UpdatePayment")]
        public async Task<ActionResult<CreatePaymentCommandResponse>> UpdatePayment([FromBody] UpdatePaymentCommand updatePaymentCommand)
        {
            var response = await _mediator.Send(updatePaymentCommand);
            return Ok(response);
        }

        [HttpDelete("Payment/delete", Name = "DeletePayment")]
        public async Task<ActionResult<DeletePaymentCommandResponse>> DeletePayment([FromBody] DeletePaymentCommand deletePaymentCommand)
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

    }
}