﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Wallet
{
    public class WalletNumberDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }
}