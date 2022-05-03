using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentProcessingRepositories;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.EntityEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips
{
    public class GetTripActionAndStatusQueryHandler : IRequestHandler<GetTripActionAndStatusQuery, TripActionAndStatusViewModel>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public GetTripActionAndStatusQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<TripActionAndStatusViewModel> Handle(GetTripActionAndStatusQuery request, CancellationToken cancellationToken)
        {
            var actions = Enum.GetValues(typeof(ActionType)).Cast<ActionType>().ToList();
            var statuses = Enum.GetValues(typeof(TrackingStatus)).Cast<TrackingStatus>().ToList();

            var listAction = new List<OptionValue>();
            var listStatus = new List<OptionValue>();

            foreach (var item in actions)
            {
                var val = new OptionValue
                {
                    Name = (int)item,
                    Value = item.GetEnumDescription(), 
                };

                listAction.Add(val);
            }

            foreach (var item in statuses)
            {
                var val = new OptionValue
                {
                    Name = (int)item,
                    Value = item.GetEnumDescription()
                };

                listStatus.Add(val);
            }

            var result = new TripActionAndStatusViewModel
            {
                Status = listStatus,
                Actions = listAction
            };

            return result;
        }



    }

    public static class helper
    {   
        public static string GetEnumDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attr.Length == 0 ? value.ToString() : (attr[0] as DescriptionAttribute).Description; ;
        }

    }



    public class GetTripActionAndStatusQuery : IRequest<TripActionAndStatusViewModel>
    {
    }

    public class TripActionAndStatusViewModel
    {
        public List<OptionValue> Actions { get; set; }
        public List<OptionValue> Status { get; set; }
    }

    public class OptionValue
    {
        public int Name { get; set; }
        public string Value { get; set; }
    }
}