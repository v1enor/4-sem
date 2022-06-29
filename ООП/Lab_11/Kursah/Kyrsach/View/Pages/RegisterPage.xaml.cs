using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kyrsach.Model;
using NBitcoin;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private MailSender MainFunc = new MailSender();
        private GenerateSeed generateSeed = new GenerateSeed();
        private bool flag = false;

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RegLogin.Text.Length > 2 && RegLogin.Text.Length < 40)
            {
                if (RegPWDPasswordBox.Password == RegPWDPasswordBox2.Password && RegPWDPasswordBox2.Password != "")
                {
                    if (App.Authentication.IsValidEmail(RegMail.Text))
                    {
                        try
                        {
                            if(new Mnemonic(SEED.Text, Wordlist.English).IsValidChecksum)
                            {
                                Application.Current.Resources["SaveLogin"] = RegMail.Text;

                                MainFunc.SendEmail();
                                CheckMailCode.Visibility = Visibility.Visible;
                                CheckMailCode2.Visibility = Visibility.Visible;
                                CheckMail.Visibility = Visibility.Hidden;
                                CheckMailCodey.Visibility = Visibility.Visible;
                                CheckMailCodey.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                MessageBox.Show("Слов то хватает, НО не то что надо Ж(");
                            }
                           

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message); 
                        }
                    }

                    else
                        {
                            MessageBox.Show("Email не подходит");
                        }


                }
                else
                {
                    MessageBox.Show("Введите пароли, они должны быть одинокавы");
                }


            }
            else
            {
                MessageBox.Show("Логин должен быть от 3 до 40");
            }
        }

        private void GenerateSeed(object sender, RoutedEventArgs e)
        {
            generateSeed.GenerateMnemo();
            SEED.SetResourceReference(TextBox.TextProperty, "MNEMO");
        }

        private void CheckMailCode3(object sender, RoutedEventArgs e)
        {

            if (App.Authentication.CheckMail(CheckMailCode.Text, Application.Current.Resources["Code"].ToString()))
            {
                MessageBox.Show("Почта подтверждена");
                CheckMailCodey.Visibility = Visibility.Hidden;
                CheckMail2.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Неверный код");
            }

            ;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            CheckMail.Visibility = Visibility.Hidden;


            flag = true;
            if (flag)
            {
                if (App.Authentication.Register(RegLogin.Text, RegPWDPasswordBox.Password, RegMail.Text, SEED.Text))
                {
                    MessageBox.Show("Аккаунт зарегестрирован");
                    NavigationService.Navigate(new PageLogin());
                }
                else
                {
                    MessageBox.Show("Аккаунт не зарегестрирован");
                }
            }
            else
            {
                CheckMail.Visibility = Visibility.Hidden;
            }
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}