﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Business.Shipments.Queries.GetShipmentList
{
    class GetShipmentListQuery : IRequest<List<ShipmentListViewModel>>
    {
    }
}
