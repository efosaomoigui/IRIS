using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Payments.Commands.UpdateNumber 
{
    public class UpdateNumberCommand : IRequest<UpdateNumberCommandResponse> 
    {
        public Guid NumberId { get; set; }
        public string ServiceCentreCode { get; set; }
        public NumberGeneratorType NumberGeneratorType { get; set; }
        public string NumberCode { get; set; }
    }
}