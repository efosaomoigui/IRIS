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

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            //var client = new SimpleEmailS(_emailSettings.ApiKey); //AWS Email

            var subject = email.Subject;
            var body = email.Body;

            var templatebody = GetHtmlTemplate("EmailTemp.html");

            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("iris@chiscoexpress.com", "IRIS");
            sendGridMessage.AddTo("efe.omoigui@gmail.com");
           

            //The Template Id will be something like this - d-9416e4bc396e4e7fbb658900102abaa2

            sendGridMessage.SetTemplateId("d-b87f6cab7b0a4dd490d026394de53ab7");
            //Here is the Place holder values you need to replace.

            sendGridMessage.SetTemplateData(new
            {
                name = "Efosa",
                url = "https://admin.chiscoiris.com"
            });

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

            return false;
        }

        //public SendGridMessage PrepareHtmlDynamicTemplate(EmailOptions options)  
        ////{
        //    var emailTemplatePath = $"{Directory.GetCurrentDirectory()}/EmailTemplates/{templateName}";
        //    var sb = new StringBuilder();

        //    return sb.ToString();
        //}

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
