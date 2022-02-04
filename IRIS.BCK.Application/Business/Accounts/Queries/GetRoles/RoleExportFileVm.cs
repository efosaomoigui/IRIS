namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles
{
    public class RoleExportFileVm
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] data { get; set; } 
    }
}