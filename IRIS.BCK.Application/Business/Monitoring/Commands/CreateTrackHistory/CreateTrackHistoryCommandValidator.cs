using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory
{
    public class CreateTrackHistoryCommandValidator : AbstractValidator<CreateTrackHistoryCommand>
    {
        public ITrackHistoryRepository _trackHistoryRepository { get; set; }

        public CreateTrackHistoryCommandValidator(ITrackHistoryRepository trackHistoryRepository)
        {
            _trackHistoryRepository = trackHistoryRepository;

            RuleFor(p => p.Location)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Status)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.TimeStamp)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            RuleFor(p => p.Trip)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
        }
    }
}