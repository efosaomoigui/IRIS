using IRIS.BCK.Core.Application.DTO.Message;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Domain.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail  
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email, EmailOptions options = null);
    }

    public class EmailOptions
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverAddress { get; set; }
        public Values Shipment { get; set; }
    }
}
