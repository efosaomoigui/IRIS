using IRIS.BCK.Core.Application.DTO.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IRepositories.IShipmentRepositories
{
    public interface ExportShipmentsToCsv 
    {
        byte[] ExportShipmentsToCsv(List<ShipmentExportDto> shipmentexportdto);
    }

}
