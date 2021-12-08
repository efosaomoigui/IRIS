using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Shipment
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllShipments")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetAllShipments()
        {
            var shipments = _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }
    }
}
