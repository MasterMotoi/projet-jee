using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace notificationBusiness
{
    public class pdfGenerator
    {
        public String generatePdf(string key ,int ValidityRate, model.File decryptedFile)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Decryption Report -"+key+" "+ decryptedFile.name;
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Regular);
            string text = "Fichier : " + decryptedFile.name + " | Clé : " + key + " | Taux de confiance : " + Convert.ToString(ValidityRate);
            XTextFormatter tf = new XTextFormatter(gfx);
            tf.DrawString(text, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
            //gfx.DrawString(text, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height),XStringFormats.Center);
            //string test = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\Desktop\\Decryption Report -" + key + " " + decryptedFile.name + ".pdf";

            document.Save(filename);

            Process.Start(filename);
            return filename;
        }
    }
}
