using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using OfficeMaintanenceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMaintanenceCommon.Helper
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(AddUserModel emailInfo)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailSettings.EMail);
            email.To.Add(MailboxAddress.Parse(emailInfo.Email));
            email.Subject = "Urban Design Tech";

            // Read HTML template file
            string htmlBody;
            using (StreamReader reader = new StreamReader(@"D:\Demo-OfficeProject\OfficeMaintenanceApi\OfficeMaintanenceCommon\EmailTemplate.html"))
            {
                htmlBody = await reader.ReadToEndAsync();
            }

            // Replace placeholders with actual data
            htmlBody = htmlBody.Replace("{Username}", emailInfo.Email);
            htmlBody = htmlBody.Replace("{Password}", emailInfo.PassWord);

            var builder = new BodyBuilder();
            builder.HtmlBody = htmlBody;
            email.Body = builder.ToMessageBody();

            var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.EMail, _emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

    }
}
