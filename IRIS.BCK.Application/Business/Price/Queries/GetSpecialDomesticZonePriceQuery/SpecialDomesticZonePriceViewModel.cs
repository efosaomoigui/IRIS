using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetSpecialDomesticZonePriceQuery
{
    public class SpecialDomesticZonePriceViewModel
    {
        public int PriceId { get; set; }

        public decimal? Weight { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        public int SpecialDomesticPackageId { get; set; }
        public virtual SpecialDomesticPackage SpecialDomesticPackage { get; set; }
    }
}