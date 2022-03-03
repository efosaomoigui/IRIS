﻿using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IGroupWayBillManifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.CreateGroupWayBillManifestMap
{
    public class CreateGroupWayBillManifestMapCommandValidator : AbstractValidator<CreateGroupWayBillManifestMapCommand>
    {
        public IGroupWayBillManifestMapRepository _groupWayBillManifestRepository { get; set; }

        public CreateGroupWayBillManifestMapCommandValidator(IGroupWayBillManifestMapRepository groupWayBillManifestRepository)
        {
            _groupWayBillManifestRepository = groupWayBillManifestRepository;

            RuleFor(p => p.GroupWayBillCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.ManifestCode)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
            {
            }
        }
    }
}