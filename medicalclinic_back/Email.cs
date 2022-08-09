using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows;

namespace medicalclinic_back
{
    public static class Email
    {
        public static string sendEmail(string body, string subjcet,string email)
        {
            try
            {
                MailMessage message = new MailMessage("tester@vfczjombdo.cfolks.pl", email);
                message.Subject = subjcet;
                message.Body = body;
                message.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("vfczjombdo.cfolks.pl", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "tester@vfczjombdo.cfolks.pl",
                    Password = "hF-.cozq6O3I@-Za"
                };
                //smtpClient.EnableSsl = true;
                smtpClient.Send(message);
                return "Wiadomość z linkiem do zmiany hasła została wysłana na email: " + email;
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd. Spróbuj ponownie później");
                return "nie udało wysłać się wiadomości";
            }
            
        }
    }
}
