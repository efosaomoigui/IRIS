using System.ComponentModel;

namespace IRIS.BCK.Core.Domain.EntityEnums
{
    public enum TrackingStatus
    {
        [Description("Shipment Registered and Moved to Processing")]
        Shipment_Registered_and_Moved_to_Processing = 10,

        [Description("Processing Completed, Ready For Dispatched")]
        Processing_Completed__Ready_For_Dispatched = 20,

        [Description("Shipment Registered For Dispatch")]
        Shipment_Registered_For_Dispatch = 30,

        [Description("Shipment In Transit to Distination")]
        Shipment_In_Transit_to_Distination = 40,

        [Description("Shipment At Destination, Ready For Delivery Processing")]
        Shipment_At_Destination__Ready_For_Delivery_Processing = 50,

        [Description("Package Ready For Collection")]
        Package_Ready_For_Collection = 60,
    }
}