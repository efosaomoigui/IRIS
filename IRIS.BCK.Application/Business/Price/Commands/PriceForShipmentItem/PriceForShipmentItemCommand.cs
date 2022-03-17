﻿using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem
{ 
    public class PriceForShipmentItemCommand : IRequest<PriceForShipmentItemCommandResponse>
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; } 
        public decimal LineTotal { get; set; }
        public ShipmentCategory ShimentCategory { get; set; } 
        public string RouteId { get; set; }  
    }
}