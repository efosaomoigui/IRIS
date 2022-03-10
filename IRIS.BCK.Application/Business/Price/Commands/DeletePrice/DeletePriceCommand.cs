using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.DeletePrice
{
    public class DeletePriceCommand : IRequest<DeletePriceCommandResponse>
    {
        public Guid Id { get; set; }

        //public PriceCategory Category { get; set; }

        public Guid RouteId { get; set; }

        public virtual Route Route { get; set; }
        public decimal UnitWeight { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}