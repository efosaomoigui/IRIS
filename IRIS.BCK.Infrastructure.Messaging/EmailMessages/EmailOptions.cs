using IRIS.BCK.Core.Domain.EntityEnums;
using System.Collections.Generic;

namespace IRIS.BCK.Infrastructure.Messaging.EmailMessages
{
    public class EmailOptions
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverAddress { get; set; } 
        public List<Values> Shipment { get; set; }  
    }
}