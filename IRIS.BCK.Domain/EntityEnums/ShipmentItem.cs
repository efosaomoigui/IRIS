using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Domain.EntityEnums
{
    public class ShipmentItem
    {
        public Guid ShipmentItemId { get; set; }
        public double Weight { get; set; } 
        public double length { get; set; }
        public double breadth { get; set; }
        public double Height { get; set; }
        public string DimensionUnit { get; set; } //cm / in
        public string ShipmentDescription { get; set; }
        public ProductEnum ShipmentProduct { get; set; } 
        public Shipment Shipment { get; set; }
        public double LineTotal { get; set; } 
    }

    public class ItemsA
    {
        public double ton { get; set; }
        public string t_shipmentDescription { get; set; }
        public ProductEnum t_shipmentType { get; set; }
        public double LineTotal { get; set; }
    }

    public class ItemsB
    {
        public double weight { get; set; }
        public double length { get; set; }
        public double breadth { get; set; }
        public double height { get; set; }
        public string m_shipmentDescription { get; set; }
        public double LineTotal { get; set; }
    }

    public class Values 
    {
        public string shipmentCategory { get; set; }
        public string shipperFullName { get; set; }
        public string shipperAddress { get; set; }
        public string shipperPhoneNumber { get; set; }
        public string receiverFullName { get; set; }
        public string receiverAddress { get; set; }
        public string receiverPhoneNumber { get; set; }
        public string invoiceNumber { get; set; }
        public string waybillNumber { get; set; }  
        public string route { get; set; }
        public List<ItemsA> itemsA { get; set; }
        public List<ItemsB> itemsB { get; set; }
        public int grandTotal { get; set; }
        public List<int> grandTotalArray { get; set; }
        public string paymentMethod { get; set; }
    }

}