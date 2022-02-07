using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.UsefulEntities
{
    public class WalletNumber : Auditable
    {
        public int WalletNumberId { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }

        public string UserId { get; set; }
    }

    public class WaybillTransaction : Auditable
    {
        public int WaybillTransactionId { get; set; }
        public string Amount { get; set; }
        // public TransactionType TransactionType { get; set; }

        public string UserId { get; set; }
        public string WalletNumber { get; set; }
    }

    public class SpecialDomesticZonePrice : Auditable
    {
        public int PriceId { get; set; }

        public decimal? Weight { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ZoneId { get; set; }
        // public virtual Zone Zone { get; set; }

        public int SpecialDomesticPackageId { get; set; }
        // public virtual  SpecialDomesticPackage { get; set; }

        //public int UserId { get; set; }
        //public virtual User User { get; set; }
    }
}