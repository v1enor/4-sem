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
using System.Text.RegularExpressions;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminSearch.xaml
    /// </summary>
    public partial class AdminSearch : Page
    {

        public List<TransactionsList> DATA;
        public AdminSearch()
        {
            InitializeComponent();
            BindGrid();
            
        }


        public void BindGrid()
        {
            using (var db = new CursachContext())
            {
                var DATA = db.Transactions_List.ToList();
                gvData.ItemsSource = DATA;
            }

        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CountVisible(object sender, RoutedEventArgs e)
        {
            if (ByCountMin.IsEnabled || ByCountMax.IsEnabled)
            {
                ByCountMin.IsEnabled = false;
                ByCountMax.IsEnabled = false;
                ByCountMax.Clear();
                ByCountMin.Clear();


            }
            else if (!ByCountMin.IsEnabled || !ByCountMax.IsEnabled)
            {

                ByCountMin.IsEnabled = true;
                ByCountMax.IsEnabled = true;
            }
        }

        private void FeeVisible(object sender, RoutedEventArgs e)
        {

            if (ByFeeMin.IsEnabled || ByFeeMax.IsEnabled)
            {
                ByFeeMin.IsEnabled = false;
                ByFeeMax.IsEnabled = false;
                ByFeeMin.Clear();
                ByFeeMax.Clear();

            }
            else if (!ByFeeMin.IsEnabled || !ByFeeMax.IsEnabled)
            {

                ByFeeMin.IsEnabled = true;
                ByFeeMax.IsEnabled = true;
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FindTransaction(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var db = new CursachContext())
                {
                    var DATA = db.Transactions_List.ToList();

                    try
                    { 
                        if (ByCountMin.Text != "")
                        {
                            DATA = DATA.Where(x => x.Amount >= Convert.ToDecimal(ByCountMin.Text)).ToList();
                        }
                        if (ByCountMax.Text != "")
                        {
                            DATA = DATA.Where(x => x.Amount <= Convert.ToDecimal(ByCountMax.Text)).ToList();
                        }
                        if (ByFeeMin.Text != "")
                        {
                            DATA = DATA.Where(x => x.Fee >= Convert.ToDecimal(ByFeeMin.Text)).ToList();
                        }
                        if (ByFeeMax.Text != "")
                        {
                            DATA = DATA.Where(x => x.Fee <= Convert.ToDecimal(ByFeeMax.Text)).ToList();
                        }
                        if (SearchHash.Text != "")
                        {
                            DATA = DATA.Where(x => x.TxHash.Contains(SearchHash.Text)).ToList();
                        }
                        if (SearchFrom.Text != "")
                        {
                            DATA = DATA.Where(x => x.FromAdress.Contains(SearchFrom.Text)).ToList();
                        }
                        
                        if (SearchTo.Text != "")
                        {
                            DATA = DATA.Where(x => x.ToAdress.Contains(SearchTo.Text)).ToList();
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Введите коректные данные для фильтрации");
                    }

                    gvData.ItemsSource = DATA;
                }
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }
    }
}
