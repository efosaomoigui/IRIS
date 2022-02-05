using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Fleets.Queries.GetFleets
{
    public class GetFleetQuery : IRequest<List<FleetListViewModel>>
    {
    }
}