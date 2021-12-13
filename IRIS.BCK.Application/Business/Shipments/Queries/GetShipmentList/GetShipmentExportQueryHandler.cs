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

namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList
{
    class GetShipmentExportQueryHandler : IRequestHandler<GetShipmentExportQuery, ShipmentExportFileVm>
    {
        private readonly IGenericRepository<Shipment> _shipmentRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvexporter; 

         
        public GetShipmentExportQueryHandler(IGenericRepository<Shipment> shipmentRepository, IMapper mapper, ICsvExporter csvexporter)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
            _csvexporter = csvexporter;
        }

        public async Task<ShipmentExportFileVm> Handle(GetShipmentExportQuery request, CancellationToken cancellationToken)
        {
            var shipmentResult = (await _shipmentRepository.GetAllAsync()).OrderBy(x => x.CreatedDate);
            var allShipments = _mapper.Map<List<ShipmentExportDto>>(shipmentResult);

            var fileData = _csvexporter.ExportFilesToCsv(allShipments);
            var shipmentexportdto = new ShipmentExportFileVm()
            {
                ContentType = "Text/csv",
                data = fileData,
                ShipmentExportFileName = $"{Guid.NewGuid()}.csv"
            };

            return shipmentexportdto;
        }
    }
}
