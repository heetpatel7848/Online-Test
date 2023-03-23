using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SendEmailDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IConfiguration _mail;
        public SendEmailController(IConfiguration mail)
        {
            _mail = mail.GetSection("EmailConfig");
        }
        [HttpGet]
        public void SendEmail(string recipient, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mail services", "heetpatel784807@gmail.com"));
            message.To.Add(new MailboxAddress("Hemlo", recipient));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            var client = new SmtpClient();
            client.Connect(_mail["Host"],Convert.ToInt32( _mail["Port"]), SecureSocketOptions.StartTls);

            // Authenticate with Gmail using your email address and password
            client.Authenticate(_mail["From"], _mail["Password"]);

            // Send the email message and block until it's sent
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
