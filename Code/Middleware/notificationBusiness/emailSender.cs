using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace notificationBusiness
{
    public class emailSender
    {
        public  void sendEmail(string email, string pdfFilename, model.File decryptedFile)
        {
            string to = email;
            string from = "projeta4dev@gmail.com";
            string pwd = "Password693";

            //smtp
            SmtpClient client = new SmtpClient();
            client.Port=587; //TLS
            client.Host= "smtp.gmail.com"; //smtp.gmail.com
            client.EnableSsl =true;
            client.DeliveryMethod=SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from, pwd);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.To.Add(to);
            message.Subject = "Successfull decryption";
            message.Body = @"L'application à decrypté un fichier avec un taux de confiance acceptable.";

            Attachment pdf = new Attachment(pdfFilename);
            message.Attachments.Add(pdf);
            try
            {
                if (File.Exists(decryptedFile.name))
                {
                    File.Delete(decryptedFile.name);
                }
                using (FileStream fs = File.Create(decryptedFile.name))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes(decryptedFile.data);
                    fs.Write(title, 0, title.Length);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            Attachment file = new Attachment(decryptedFile.name);
            message.Attachments.Add(file);
            try
            {
                client.Send(message);
                Console.WriteLine("successful email");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }
    }
}
