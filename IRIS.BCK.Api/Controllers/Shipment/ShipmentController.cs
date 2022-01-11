﻿using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIS.BCK.Api.Controllers.Shipment
{
    public class ShipmentController : BaseApiController
    {
        private readonly IMediator _mediator;
        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("all", Name = "GetAllShipments")]
        public async Task<ActionResult<List<ShipmentListViewModel>>> GetAllShipments()
        {
            var shipments = await _mediator.Send(new GetShipmentListQuery());
            return Ok(shipments);
        }

        [HttpPost(Name ="AddShipment")]
        public async Task<ActionResult<CreateShipmentCommandResponse>> Create([FromBody] ShipmentDto createShipmentCommand)
        {
            var response = await _mediator.Send(createShipmentCommand);
            return Ok(response);
        }
    }
}
