using IRIS.BCK.Core.Application.Business.Price.Commands.SpecialDomesticZonePrice;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings.Price
{
    public static class SpecialDomesticZonePriceMapsCommand
    {
        public static SpecialDomesticZonePrice CreateSpecialDomesticZonePriceMapsCommand(CreateSpecialDomesticZonePriceCommand request)
        {
            return new SpecialDomesticZonePrice
            {
                Description = request.Description,
                ZoneId = request.ZoneId,
                Zone = request.Zone,
                Weight = request.Weight,
                Price = request.Price,
                PriceId = request.PriceId,
                SpecialDomesticPackage = request.SpecialDomesticPackage,
                SpecialDomesticPackageId = request.SpecialDomesticPackageId
            };
        }
    }
}