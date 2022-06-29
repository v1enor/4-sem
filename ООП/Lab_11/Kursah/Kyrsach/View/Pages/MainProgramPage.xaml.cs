using Kyrsach.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Application = System.Windows.Application;


namespace Kyrsach.View.Pages
{

    public partial class MainProgramPage : Page
    {

        public MainProgramPage()
        {
            Application.Current.Resources["CurID"] = 1;
            InitializeComponent();
            TokenSelect.SelectedIndex = Convert.ToInt32(Application.Current.Resources["CurID"].ToString()) - 1;
            bool admin = (bool)Application.Current.Resources["Admin"];
            
            if (admin)
            {
                AdminPanel.Visibility = Visibility.Visible;
            }
            
            else if (!admin)
            {
                AdminPanel.Visibility = Visibility.Collapsed;
            }
        }
        private void CopyInBufer(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(Balance.Text.Replace(".",","));
            System.Windows.MessageBox.Show("Скопировано в буфер обмена");
        }


        private void SendCUR(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SendCurrancy());
        }

        private void Receive_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Receive());
        }
        private void Admin_tokens(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Admin());
        }

        private void Admin_Search(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminSearch());
        }

        private void Admin_Users(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminRegister());
        }


        private void OpenHistoryTransaction(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoryTransaction());
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageLogin());
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var MainVM = new WalletViewModel();
            DataContext = MainVM;
            TokenSelect.SelectedIndex = Convert.ToInt32(Application.Current.Resources["CurID"].ToString()) - 1;
        }
    }
}