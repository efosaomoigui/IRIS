﻿using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.UpdateServiceCenter
{
    public class UpdateServiceCenterCommandValidator : AbstractValidator<UpdateServiceCenterCommand>
    {
        public IServiceCenterRepository _serviceCenterRepository { get; set; }

        public UpdateServiceCenterCommandValidator(IServiceCenterRepository serviceCenterRepository)
        {
            _serviceCenterRepository = serviceCenterRepository;

            RuleFor(p => p.ServiceCenterCountry)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.ServiceCenterName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}