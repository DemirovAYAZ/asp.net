using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FromMail = "thedotnetchannelsender22@gmail.com";
            string FromPassword = "lgioehkvchemfkrw";

            List<string> ToMailList = new List<string>()
            {
                "heydermuxtar26@gmail.com",
                "ayazdemirov123@gmail.com",
                "demirovayaz7@gmail.com",
                "anardemirov82@gmail.com"
            };

            MailMessage message = new MailMessage();
            message.From = new MailAddress(FromMail);
            message.Subject = "Test mail from workshop";
            message.Body = "Test body from workshop from heyder";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(FromMail, FromPassword);
            smtpClient.EnableSsl = true;

            try
            {
                foreach (string toAddress in ToMailList)
                {
                    message.To.Clear(); 
                    message.To.Add(new MailAddress(toAddress));

                    smtpClient.Send(message);

                    Console.WriteLine($"Email sent to: {toAddress}");

                    
                    Random random = new Random();
                    int randomNumber = random.Next(3, 6);
                    Thread.Sleep(randomNumber * 1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email(s): " + ex.ToString());
            }
        }
    }
}
