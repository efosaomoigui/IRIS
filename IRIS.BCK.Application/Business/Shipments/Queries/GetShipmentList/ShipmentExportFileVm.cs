namespace IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList
{
    public class ShipmentExportFileVm 
    {
        public string ShipmentExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] data { get; set; } 
    }
}