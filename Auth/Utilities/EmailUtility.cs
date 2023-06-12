using System;
using System.Net;
using System.Net.Mail;

namespace Auth.Utilities
{
    public static class EmailUtility
    {
        private static readonly string SmtpServer = "smtp.gmail.com";
        private static readonly int SmtpPort = 587;
        private static readonly string SmtpUsername = "mungai.developer@gmail.com";
        private static readonly string SmtpPassword = "L4Wy3R$Hub!";

        public static void SendEmail(string recipient, string subject, string body)
        {
            using (var message = new MailMessage())
            {
                message.From = new MailAddress(SmtpUsername);
                message.To.Add(recipient);
                message.Subject = subject;
                message.Body = body;

                using (var smtpClient = new SmtpClient(SmtpServer, SmtpPort))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }
            }
        }
    }
}
