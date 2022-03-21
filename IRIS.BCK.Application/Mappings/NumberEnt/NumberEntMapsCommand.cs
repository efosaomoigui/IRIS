using IRIS.BCK.Core.Application.Business.Payments.Commands.CreateNumberEnt;
using IRIS.BCK.Core.Application.Business.Payments.Commands.CreatePayment;
using IRIS.BCK.Core.Domain.Entities.NumberEnt;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Payments
{
    public static class NumberMapsCommand
    {
        public static NumberEnt CreateNumberMapsCommand(CreateNumberCommand request)
        {
            return new NumberEnt
            {
               NumberEntId = request.NumberId,
               ServiceCentreCode = request.ServiceCentreCode,
               NumberCode = request.NumberCode, 
               NumberGeneratorType = request.NumberGeneratorType
            };
        }
    }
}