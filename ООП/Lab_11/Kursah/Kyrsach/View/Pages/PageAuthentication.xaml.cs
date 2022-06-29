using Kyrsach.View.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class PageAuthentication : Page
    {
        bool flag = true;
        MailSender MainFunck = new MailSender();
        
        public PageAuthentication()
        {
            InitializeComponent();
        }
        private void AcessBTN(object sender, RoutedEventArgs e)
        {
            if (App.Authentication.CheckMail(CheckCode.Text,App.Current.Resources["Code"].ToString()))
            {
                MessageBox.Show("Добро пожаловать");   
                NavigationService.Navigate(new MainProgramPage());
            }
            else
            MessageBox.Show("Код не верный");
        }
        private void RepetCode(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                MainFunck.SendEmail();
                flag = false;
            }
            else
                MessageBox.Show("Больше не отправим");
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
