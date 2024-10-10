using Backend.Models;
using Backend.Models.VM;
using System.Net;
using System.Net.Mail;

namespace Backend.Controllers.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetEmail()
        {
            var email = _configuration["MailSettings:Mail"];
            if (email != null)
            {
                return email;
            }
            else { return "EMPTY"; }
        }
        private string GetDisplayName()
        {
            var displayName = _configuration["MailSettings:DisplayName"];
            if (displayName != null)
            {
                return displayName;
            }
            else { return "EMPTY"; }
        }

        private string GetPassword()
        {
            var password = _configuration["MailSettings:Password"];
            if (password != null)
            {
                return password;
            }
            else { return "EMPTY"; }
        }

        private string GetHost()
        {
            var host = _configuration["MailSettings:Host"];
            if (host != null)
            {
                return host;
            }
            else { return "EMPTY"; }
        }

        private int GetPort()
        {
            var port = _configuration["MailSettings:Port"];
            if (port != null)
            {
                int portParsed = int.Parse(port);
                return portParsed;
            }
            else { return -1; }
        }

        /// <summary>
        /// Send email with link to redeem poap.
        /// </summary>
        /// <param name="mailRequest">MailRequest to send email with link to redeem poap</param>
        public void SendEmail(MailRequest mailRequest)
        {
            string Body = "<p>Obrigado por participar no nosso Evento.</p>";
            string FromEmail = GetEmail();
            string DisplayName = GetDisplayName();
            string Password = GetPassword();
            string Host = GetHost();
            int Port = GetPort();

            if (FromEmail.Equals("EMPTY") || DisplayName.Equals("EMPTY")
                || Password.Equals("EMPTY") || Host.Equals("EMPTY") || Port == -1)
            {
                throw new Exception("EMPTY MAIL SETTINGS");
            }

            var _mailRequest = new MailRequest(mailRequest.ToEmail, mailRequest.Subject, mailRequest.Link);

            MailAddress source = new(FromEmail, DisplayName);
            MailAddress target = new(_mailRequest.ToEmail);

            MailMessage message = new(source, target)
            {
                Subject = _mailRequest.Subject,
                Body = Body + "<p>Clique neste <a href=\"" + _mailRequest.Link + "\">link</a> para redimir o seu Poap.</p>",
                IsBodyHtml = true
            };

            try
            {
                SmtpClient client = new();
                client.Host = Host;
                client.Port = Port;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                NetworkCredential credential = new(FromEmail, Password);
                client.Credentials = credential;

                client.Send(message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Send email with credentials to the high priority users.
        /// </summary>
        /// <param name="userHP">CreateUserHP to create user</param>
        /// <param name="password">Password generate for the user</param>
        public void SendEmailPassword(CreateUserHP userHP, string password)
        {
            string Body = "<p>Obrigado por criar uma conta, aqui estão as suas credenciais.</p>";
            string FromEmail = GetEmail();
            string DisplayName = GetDisplayName();
            string Password = GetPassword();
            string Host = GetHost();
            int Port = GetPort();

            if (FromEmail.Equals("EMPTY") || DisplayName.Equals("EMPTY")
                || Password.Equals("EMPTY") || Host.Equals("EMPTY") || Port == -1)
            {
                throw new Exception("EMPTY MAIL SETTINGS");
            }

            var _mailRequest = new MailRequest(userHP.Email, "Credentials");

            MailAddress source = new(FromEmail, DisplayName);
            MailAddress target = new(_mailRequest.ToEmail);

            MailMessage message = new(source, target)
            {
                Subject = _mailRequest.Subject,
                Body = Body + "<p>User Name: " + userHP.UserName + "</p>" + "<p>Email: " + userHP.Email + "</p>" + "<p>Password: " + password + "</p>",
                IsBodyHtml = true
            };

            try
            {
                SmtpClient client = new();
                client.Host = Host;
                client.Port = Port;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                NetworkCredential credential = new(FromEmail, Password);
                client.Credentials = credential;

                client.Send(message);
            }
            catch (Exception)
            {
                throw new Exception("Email");
            }
        }
    }
}
