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

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            BindGrid();
        }


        public void BindGrid()
        {
            using (var db = new CursachContext())
            {
                gvData.ItemsSource = db.CurrencyList.ToList();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDecimal(txtPR.Text) <= 0)
            {
                MessageBox.Show("Введите положитеьлное число");
                return;
            }



            if (txtCID.Text != "")
            {
                try
                {
                    if (btnAdd.Content.ToString() == "Обновить")
                    {
                        try
                        {


                            using (var db = new CursachContext())
                            {
                                var id = Convert.ToDecimal(txtCID.Text);
                                var tokens = db.CurrencyList.Where(x => x.IdCurrency == id).FirstOrDefault();
                                tokens.Abbrecitation = txtABB.Text;
                                tokens.Price = Convert.ToDecimal(txtPR.Text);
                                tokens.ExplorerSite = txtES.Text;
                                tokens.TokenSite = txtTSITE.Text;
                                db.SaveChanges();
                                BindGrid();
                                ClearAll();
                                btnAdd.Content = "Add";
                            }
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Введите кореектные данные, я же тоже человек!");
                        }
                    }
                    
                    else
                    {
                        using (var db = new CursachContext())
                        {
                            CurrencyList tokens = new CurrencyList()
                            {
                                IdCurrency = Convert.ToInt32(txtCID.Text),
                                Abbrecitation = txtABB.Text,
                                Price = Convert.ToDecimal(txtPR.Text),
                                ExplorerSite = txtES.Text,
                                TokenSite = txtTSITE.Text
                            };



                            db.CurrencyList.Add(tokens);
                            db.SaveChanges();
                            BindGrid();
                            ClearAll();
                        }
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Введите коректные данные, я же тоже человек!"); ;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста введите ID");
            }


        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
           
                try
                {

                    using (var db = new CursachContext())
                    {
                        var id = Convert.ToInt32(txtCID.Text);
                        var tokens = db.CurrencyList.Where(x => x.IdCurrency == id).FirstOrDefault();
                        db.CurrencyList.Remove(tokens);
                        db.SaveChanges();
                        BindGrid();
                        ClearAll();
                        MessageBox.Show("МЫ ВСЕ МОЛОДЦЫ, МЫ ЕГО УДАЛИЛИ!");
                     }
                }
                catch (Exception)
                {

                    MessageBox.Show("Выберите поле пжпж");
                }
            
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
                if (gvData.SelectedItems.Count == 1)
                {
                    CurrencyList row = (CurrencyList)gvData.SelectedItems[0];
                    txtCID.Text = row.IdCurrency.ToString();

                    txtABB.Text =   row.Abbrecitation.ToString();
                    txtPR.Text  =   row.Price.ToString();
                    txtES.Text  =   row.ExplorerSite.ToString();
                    txtTSITE.Text = row.TokenSite.ToString();
                
                    txtCID.IsEnabled = false;
                    btnAdd.Content = "Обновить";
                }
                else
                {
                    MessageBox.Show("Выберите поле пжпж"); ;
                 }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtCID.Text = "";
            txtABB.Text = "";
            txtPR.Text = "";
            txtES.Text = "";
            txtTSITE.Text = "";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
