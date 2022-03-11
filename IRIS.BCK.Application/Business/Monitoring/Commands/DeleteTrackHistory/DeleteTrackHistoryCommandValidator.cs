using FluentValidation;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IMonitoringRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.DeleteTrackHistory
{
    public class DeleteTrackHistoryCommandValidator : AbstractValidator<DeleteTrackHistoryCommand>
    {
        public ITrackHistoryRepository _trackHistoryRepository { get; set; }

        public DeleteTrackHistoryCommandValidator(ITrackHistoryRepository trackHistoryRepository)
        {
            _trackHistoryRepository = trackHistoryRepository;

            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}