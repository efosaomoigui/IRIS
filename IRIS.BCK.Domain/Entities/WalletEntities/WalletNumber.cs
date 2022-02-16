﻿using IRIS.BCK.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.Entities.WalletEntities
{
    public class WalletNumber : Auditable
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }

        public string UserId { get; set; }
    }
}