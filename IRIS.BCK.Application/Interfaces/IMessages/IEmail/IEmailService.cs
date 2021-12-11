using IRIS.BCK.Core.Application.DTO.Message;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail  
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
