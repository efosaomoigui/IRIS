using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IServiceCenterRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.DeleteServiceCenter
{
    public class DeleteServiceCenterCommandValidator : AbstractValidator<DeleteServiceCenterCommand>
    {
        public IServiceCenterRepository _serviceCenterRepository { get; set; }

        public DeleteServiceCenterCommandValidator(IServiceCenterRepository serviceCenterRepository)
        {
            _serviceCenterRepository = serviceCenterRepository;

            RuleFor(p => p.ServiceCenterId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}