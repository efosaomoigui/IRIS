using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseApiController
    {
        [HttpPost("Payment", Name = "AddPayment")]
        public async Task<ActionResult<CreatePaymentCommandResponse>> Create([FromBody] CreatePaymentCommand createPaymentCommand)
        {
            var response = await _mediator.Send(createPaymentCommand);
            return Ok(response);
        }
    }
}