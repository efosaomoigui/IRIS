using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Queries.GetServiceCenter
{
    public class GetServiceCenterJsonQueryHandler : IRequestHandler<GetServiceCenterJsonQuery, List<ServiceCenterJsonListViewModel>>
    {
        private readonly IGenericRepository<ServiceCenter> _serviceCenterRepository;
        private readonly IMapper _mapper;

        public GetServiceCenterJsonQueryHandler(IGenericRepository<ServiceCenter> serviceCenterRepository, IMapper mapper)
        {
            _serviceCenterRepository = serviceCenterRepository;
            _mapper = mapper;
        }

        public async Task<List<ServiceCenterJsonListViewModel>> Handle(GetServiceCenterJsonQuery request, CancellationToken cancellationToken)
        {
            //var allServiceCenter = (await _serviceCenterRepository.GetAllAsync()).OrderBy(x => x.ServiceCenterName);
            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string ServiceCenters = Path.Combine(currentDirectory, "ServiceCenters");

            string jsonString = File.ReadAllText(ServiceCenters+ @"\ServiceCenters.json"); 
            var resultValues = JsonConvert.DeserializeObject<List<ServiceCenterJsonListViewModel>>(jsonString);
            return resultValues;
        }
    }
}