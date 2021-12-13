using IRIS.BCK.Core.Application.DTO.Files.Csv;
using IRIS.BCK.Core.Application.DTO.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IFiles.ICsv
{
    public interface ICsvExporter
    {
        byte[] ExportFilesToCsv(List<ShipmentExportDto> fileexportdto); 
    }
}
