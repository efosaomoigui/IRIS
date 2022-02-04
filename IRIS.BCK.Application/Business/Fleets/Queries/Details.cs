using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IFiles.ICsv;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Fleets.Queries
{
    public class Details
    {
        public class Query : IRequest<List<FleetListViewModel>>
        {

        }

        public class Handler : IRequestHandler<Query, List<FleetListViewModel>>
        {
            private readonly IGenericRepository<Fleet> _fleetRepository;
            private readonly IMapper _mapper;
            private readonly ICsvExporter _csvexporter;

            public Handler(IGenericRepository<Fleet> fleetRepository, IMapper mapper, ICsvExporter csvexporter)
            {
                _fleetRepository = fleetRepository;
                _mapper = mapper;
                _csvexporter = csvexporter;
            }
            public Task<List<FleetListViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
