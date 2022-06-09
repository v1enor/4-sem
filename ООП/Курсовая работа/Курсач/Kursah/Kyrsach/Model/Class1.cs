using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Kyrsach
{
    public class Class1
    {
        private Random rand = new Random();
        public int code;
        public string SaveLog;

        public void SendEmail()

        {
            code = rand.Next();
            MailAddress from = new MailAddress("aksenni.2002@gmail.com", "VA_Crypto");
            MailAddress to = new MailAddress(App.Current.Resources["SaveLogin"].ToString());
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Код для входа";
            m.Body = code.ToString();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("aksenni.2002@gmail.com", "lrcndrelxdypfxiv");
            smtp.Send(m);
            App.Current.Resources["Code"] = code;
           
            MessageBox.Show("Письмо отправлено");
        }
        

    }
}
