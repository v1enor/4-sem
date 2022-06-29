using Kyrsach.Pages;
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

namespace Kyrsach
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        bool flag = true;
        Class1 MainFunck = new Class1();
        
        public Page2()
        {
            InitializeComponent();
            
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCode.Text == App.Current.Resources["Code"].ToString())
            {
                MessageBox.Show("Добро пожаловать");
                ProgramWindow programWindow = new ProgramWindow();
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
    }
}
