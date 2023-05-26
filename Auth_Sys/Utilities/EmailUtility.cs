using System;
using System.Net;
using System.Net.Mail;

namespace Auth_Sys.Utilities
{
    public static class EmailUtility
    {
        public static void SendEmail(string toAddress, string subject, string body)
        {
            string fromAddress = "mungai.developer@gmail.com"; // Replace with your email address
            string fromPassword = "L4Wy3R$Hub!"; // Replace with your email password

            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtpClient.Send(message);
            }
        }
    }
}
