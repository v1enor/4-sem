using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.EntityFrameworkCore;
using NBitcoin;
using OxyPlot;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SendCurrancy.xaml
    /// </summary>
    public partial class SendCurrancy : Page
    {

        public SendCurrancy()
        {
            InitializeComponent();
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            using (var db = new CursachContext())
            {

                Random rnd = new Random();
                MailSender MainFunck = new MailSender();
                
                var mennomic = Application.Current.Resources["Mnenomics"];
                var uID = Application.Current.Resources["USER_ID"].ToString();
                var cID = Application.Current.Resources["CurID"].ToString();
                var mnemo = new Mnemonic(mennomic.ToString(), Wordlist.English);
                var masterKey = mnemo.DeriveExtKey("");
                var ms_l = masterKey.ToString(Network.Main);
                var key = masterKey.Derive((uint)Convert.ToInt32(cID)).ToString(Network.Main);
                
                double random_fee = rnd.NextDouble() / 10;
                var randomTxHash = Guid.NewGuid().ToString();
                
                var SendedToken = db.Tokens.Where(t => t.Adres == key).FirstOrDefault();
                var to_wallet = db.Tokens.Where(tw => tw.Adres == ToAdress.Text).FirstOrDefault();

                if((bool)LocalWallet.IsChecked && to_wallet != null)
                {
                    MessageBox.Show("А такой адрес у нас есть !");
                }
                
                else if ((bool)LocalWallet.IsChecked && to_wallet == null)
                {
                    MessageBox.Show("А такого адреса у нас нет ;(");
                    return;
                }

                try
                {   
                    if(Convert.ToDecimal(Amount.Text) <= 0)
                    {
                        MessageBox.Show("Введите положительное число");
                        return;
                    }

                    if (SendedToken.Balance > Convert.ToDecimal(Amount.Text))
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                               
                                if (to_wallet != null)
                                {
                                    var PriceFrom = db.CurrencyList.FirstOrDefault(p => p.IdCurrency == Convert.ToInt32(cID));
                                    var PriceTo = db.CurrencyList.FirstOrDefault(p => p.IdCurrency == Convert.ToInt32(to_wallet.IdCurrency));

                                    decimal PriceCof = PriceFrom.Price / PriceTo.Price;

                                    to_wallet.Balance =
                                        (to_wallet.Balance +  (Convert.ToDecimal(Amount.Text) * PriceCof) -
                                        (Convert.ToDecimal(Amount.Text) * Convert.ToDecimal(random_fee))) ;
                                }


                                var tu = db.Transactions_List.ToList();
                                var cl = db.CurrencyList.Where(c => c.IdCurrency == Convert.ToInt32(cID)).FirstOrDefault();

                                var Transaction = new TransactionsList()
                                {
                                    FromAdress = key,
                                    Date = DateTime.Now,
                                    Amount = Convert.ToDecimal(Amount.Text),
                                    Fee = Convert.ToDecimal(Amount.Text) * Convert.ToDecimal(random_fee),
                                    IdCurrency = Convert.ToInt32(cID),
                                    ToAdress = ToAdress.Text,
                                    TxHash = randomTxHash,
                                    UsdPrice = Convert.ToDecimal(cl.Price)
                                };
                                
                                db.Transactions_List.Add(Transaction);
                                SendedToken.Balance = SendedToken.Balance - Convert.ToDecimal(Amount.Text);
                                
                                db.SaveChanges();
                                transaction.Commit();
                                
                                MessageBox.Show("Транзакция успешно выполнена");
                                MainFunck.SendNotification(Transaction);
                            }
                            catch
                            {
                                transaction.Rollback();
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Не хватает деняк ;(");
                    }

                }

                catch
                {
                    MessageBox.Show("Неверный формат! не ломайте меня пожалуйста, мне больно  ༼ಢ_ಢ༽");
                }

                
            }
        }
    }
}