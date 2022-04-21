using IRIS.BCK.Core.Application.DTO.Message;
using IRIS.BCK.Core.Application.DTO.Message.EmailMessage;
using IRIS.BCK.Core.Application.Interfaces.IMessages;
using IRIS.BCK.Core.Application.Interfaces.IMessages.IEmail;
using IRIS.BCK.Core.Application.Messages.EmailMessage;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Infrastructure.Messaging.EmailMessages
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; set; }

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email, EmailOptions options = null)
        {
            if (options != null)
            {
                var client = new SendGridClient(_emailSettings.ApiKey);
                //var client = new SimpleEmailS(_emailSettings.ApiKey); //AWS Email

                var subject = email.Subject;
                var body = email.Body;

                //var templatebody = GetHtmlTemplate("EmailTemp.html");
                var sendGridMessage = PrepareHtmlDynamicTemplate(options);

                sendGridMessage.SetTemplateData(new
                {
                    name = options.Shipment.shipperFullName,
                    shipperName = options.Shipment.shipperFullName,
                    shipperAddress = options.Shipment.shipperAddress,
                    shipperPhoneNumber = options.Shipment.receiverPhoneNumber,
                    invoiceNumber = options.Shipment.invoiceNumber,
                    waybillNumber = options.Shipment.waybillNumber,

                    receiverName = options.Shipment.receiverFullName,
                    receiverAddress = options.Shipment.receiverAddress,
                    receiverPhoneNumber = options.Shipment.receiverPhoneNumber,
                }); ;

                var from = new EmailAddress
                {
                    Email = _emailSettings.FromAddress,
                    Name = _emailSettings.FromName
                };

                //var SendGridMessage = MailHelper.CreateSingleEmail(from, to, subject,body, templatebody);
                var response = await client.SendEmailAsync(sendGridMessage);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted | response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
            }


            return false;
        }

        public SendGridMessage PrepareHtmlDynamicTemplate(EmailOptions options)
        {
            var sendGridMessage = new SendGridMessage();

            sendGridMessage.SetFrom("iris@chiscoexpress.com", "IRIS");
            var obj = options.Shipment.shipperPhoneNumber;

            sendGridMessage.AddTo("efe.omoigui@gmail.com");
            sendGridMessage.SetTemplateId("d-b87f6cab7b0a4dd490d026394de53ab7");

            return sendGridMessage;
        }

        public string GetHtmlTemplate(string templateName)
        {
            var emailTemplatePath = $"{Directory.GetCurrentDirectory()}/EmailTemplates/{templateName}";
            var sb = new StringBuilder();

            using (StreamReader file = new StreamReader(emailTemplatePath))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    sb.Append(ln);
                    counter++;
                }

                file.Close();
            }

            return sb.ToString();
        }

    }
}
