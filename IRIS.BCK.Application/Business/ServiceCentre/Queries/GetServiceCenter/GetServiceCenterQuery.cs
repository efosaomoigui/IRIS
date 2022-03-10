using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Queries.GetServiceCenter
{
    public class GetServiceCenterQuery : IRequest<List<ServiceCenterListViewModel>>
    {
    }
}