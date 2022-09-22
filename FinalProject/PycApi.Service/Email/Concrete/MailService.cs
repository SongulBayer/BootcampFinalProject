using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using PycApi.Dto;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace PycApi.Service
{
    public class MailService : IMailService
    {
        public readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;
        }
        //Smtp Mail Service created
        public void SendEmail(MailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));//It is determined from which e-mail address the e-mails will be sent.
            email.To.Add(MailboxAddress.Parse(request.To));//Determine which e-mail address to go to
            email.Subject = request.Subject;//Subject Determined
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };//Mail body determined

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);//Ports and mail host added
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
