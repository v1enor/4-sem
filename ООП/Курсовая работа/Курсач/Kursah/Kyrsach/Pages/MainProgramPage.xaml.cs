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

namespace Kyrsach.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainProgramPage.xaml
    /// </summary>
    public partial class MainProgramPage : Page
    {
        public MainProgramPage()
        {
            InitializeComponent();
            Test.Text = App.Current.Resources["Code"].ToString();
        }
    }
}
