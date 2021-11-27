using AutoMapper;
using IRIS.BCK.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Application.Mappings
{

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Shipment, ShipmentListViewModel>();
            CreateMap<Shipment, CreateShipmentCommand>();
        }
    }
}
