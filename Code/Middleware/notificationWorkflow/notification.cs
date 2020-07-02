using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notificationWorkflow
{
    public class Notification
    {
        public void notify(model.MsgStruct message)
        {
            //arret thread
            //generation pdf
            string key = (string)message.data[2];

            model.File decryptedfile = new model.File();

            string[] splitedFile = ((string)message.data[1]).Split(new char[] { '|' }, 2);
            decryptedfile.name = splitedFile[0];
            decryptedfile.data = splitedFile[1];

            int validityRate = (int)message.data[3];

            notificationBusiness.pdfGenerator pdfGenerator = new notificationBusiness.pdfGenerator();

            String pdf = pdfGenerator.generatePdf(key, validityRate, decryptedfile);

            notificationBusiness.emailSender Email = new notificationBusiness.emailSender();
            Email.sendEmail("antoine.gremillet@viacesi.fr", pdf,decryptedfile);
        }
    }
}
