using System;
using System.Collections.Generic;
using System.Data;
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
using Kyrsach.ViewModel;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryTransaction.xaml
    /// </summary>
    public partial class HistoryTransaction : Page
    {
        public HistoryTransaction()
        {
            var mb = new TransactionsViewModel();
            InitializeComponent();
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var a = new TransactionsViewModel();
            var mb = new TransactionsViewModel().Transactions.ToList();
            DataGridTR.ItemsSource = null;
            DataGridTR.ItemsSource = mb;
        }

        private void Send_info(object sender, RoutedEventArgs e)
        {
            var Mail = new MailSender();
            if(DataGridTR.SelectedItems.Count == 1)
            {
                TransactionsList tr = (TransactionsList)DataGridTR.SelectedItems[0];
                 Mail.SendNotification(tr);
                
            }

            else
            {
                MessageBox.Show("Укажите поле для отправки");
            }
        }

        

    }
}