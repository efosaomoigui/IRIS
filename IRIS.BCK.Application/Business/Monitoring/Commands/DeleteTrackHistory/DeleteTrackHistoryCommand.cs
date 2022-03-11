﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Monitoring.Commands.DeleteTrackHistory
{
    public class DeleteTrackHistoryCommand : IRequest<DeleteTrackHistoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}