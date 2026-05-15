using Domain.Helpers;
<<<<<<< HEAD
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailSettings = Domain.Helpers.MailSettings;

namespace Domain.Infrastructure.ExternalServices
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IConfiguration _config;
        public EmailService(IOptions<Helpers.MailSettings> mailSettings, IConfiguration config)
=======
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class EmailService: IEmailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IConfiguration _config;
        public EmailService(IOptions<MailSettings> mailSettings, IConfiguration config)
>>>>>>> origin/sofnanash
        {
            _mailSettings = mailSettings.Value;
            _config = config;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var FromMail = _config.GetSection("MailSettings")["FromMail"];
                var DisplayName = _config.GetSection("MailSettings")["DisplayName"];
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(DisplayName, FromMail));
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
<<<<<<< HEAD
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
=======
                using var smtp = new SmtpClient();
>>>>>>> origin/sofnanash
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, _mailSettings.UseSSL);
                //var DoAuthenticate =_config.GetSection("MailSettings")["DoAuthenticate"] ;
                //if (DoAuthenticate)
                //{
                smtp.Authenticate(_mailSettings.UserMail, _mailSettings.Password);
                //}
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
<<<<<<< HEAD
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
=======
            catch (Exception)
            {
                throw;
            }
        }

>>>>>>> origin/sofnanash
    }
}
