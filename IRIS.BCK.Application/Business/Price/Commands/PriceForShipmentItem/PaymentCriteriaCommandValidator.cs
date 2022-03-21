using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IPriceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Commands.PriceForShipmentItem
{
    public class PaymentCriteriaCommandValidator : AbstractValidator<PaymentCriteriaCommandValidator> 
    {
        public IPriceEntRepository _priceRepository { get; set; }

        public PaymentCriteriaCommandValidator(PaymentCriteriaCommand priceRepository) 
        {

        }
    }
}