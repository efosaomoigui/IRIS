namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList
{
    public class UserExportFileVm
    {
        public string ShipmentExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] data { get; set; } 
    }
}