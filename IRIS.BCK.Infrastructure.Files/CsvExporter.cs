using CsvHelper;
using CsvHelper.Configuration;
using IRIS.BCK.Core.Application.DTO.Shipments;
using IRIS.BCK.Core.Application.Interfaces.IFiles.ICsv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.FileManagement
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportFilesToCsv(List<ShipmentExportDto> fileexportdto)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream)) 
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecord(fileexportdto);
            }

            return memoryStream.ToArray();
        }
    }
}
