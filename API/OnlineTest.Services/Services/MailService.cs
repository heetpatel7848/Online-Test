using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace SendEmailDemo.Service
{
    public class MailService : Interface.IMailService
    {
        public void SendEmail(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mail services", "heetpatel784807@gmail.com"));
            message.To.Add(new MailboxAddress("Hemlo", email));
            message.Subject = "checking";
            message.Body = new TextPart("plain")
            {
                Text = "checking"
            };

            var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            // Authenticate with Gmail using your email address and password
            client.Authenticate("heetpatel784807@gmail.com", "jkpakvyrceewsorf");

            // Send the email message and block until it's sent
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
