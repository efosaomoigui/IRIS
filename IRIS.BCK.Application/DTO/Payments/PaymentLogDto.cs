﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.DTO.Payments
{
    public class PaymentLogDto
    {
        public Guid PaymentId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public Guid UserId { get; set; }
        public string TransactionCode { get; set; }
    }
}