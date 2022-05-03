namespace IRIS.BCK.Core.Domain.EntityEnums
{
    public enum ShipmentType
    {
        Special,
        Regular,
        Ecommerce,
        Store
    }

    public enum ShipmentContactStatus
    {
        NotContacted,
        Contacted
    }

    public enum ShipmentCategory
    {
        MailAndParcel=1,  
        TruckLoad =2,
        InternationalFreight=3
    }    
    
    public enum ShipmentProcessingStatus
    {
        Created=1,   
        Groupped =2,
        Manifested=3,
        Dispatched = 4,
        Released = 5
    }
}