using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.DTO.Shipments;
using IRIS.BCK.Core.Application.Interfaces.IFiles.ICsv;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks; 

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList
{
    class GetUserExportQueryHandler : IRequestHandler<GetUserExportQuery, UserExportFileVm>
    {
        private readonly IGenericRepository<Shipment> _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvexporter; 

         
        public GetUserExportQueryHandler(IGenericRepository<Shipment> shipmentRepository, IMapper mapper, ICsvExporter csvexporter)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _csvexporter = csvexporter;
        }

        public async Task<UserExportFileVm> Handle(GetUserExportQuery request, CancellationToken cancellationToken)
        {
            var shipmentResult = (await _shipmentRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            var allShipments = _mapper.Map<List<ShipmentExportDto>>(shipmentResult);

            var fileData = _csvexporter.ExportFilesToCsv(allShipments);
            var shipmentexportdto = new UserExportFileVm()
            {
                ContentType = "Text/csv",
                data = fileData,
                ShipmentExportFileName = $"{Guid.NewGuid()}.csv"
            };

            return shipmentexportdto;
        }
    }
}
