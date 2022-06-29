using Kyrsach.View.Pages;
using Kyrsach.ViewModel;
using System;
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
using System.Windows.Shapes;

namespace Kyrsach.View.Windows
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            mainFrame.Content = new PageLogin();
        }

        //public static void CreateTimeoutTestMessage(string server)
        //{
        //    string to = "vlad.aksennik@mail.ru";
        //    string from = "aksennik.vlad@mail.ru";
        //    string subject = "Using the new SMTP client.";
        //    string body = @"Using this new feature, you can send an e-mail message from an application very easily.";
        //    MailMessage message = new MailMessage(from, to, subject, body);
        //    SmtpClient client = new SmtpClient(server);
        //    Console.WriteLine("Changing time out from {0} to 100.", client.Timeout);
        //    client.Timeout = 100;
        //    // Credentials are necessary if the server requires the client 
        //    // to authenticate before it will send e-mail on the client's behalf.
        //    //client.Credentials = CredentialCache.DefaultNetworkCredentials;

        //    try
        //    {
        //        client.Send(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
        //              ex.ToString());
        //    }
        //}


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SendEmail();
        }
    }
}