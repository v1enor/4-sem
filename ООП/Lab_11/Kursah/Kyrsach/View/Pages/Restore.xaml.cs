using NBitcoin;
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

    public partial class Restore : Page
    {
        public Restore()
        {
            InitializeComponent();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                pwdTextBox.Text = pwdPasswordBox.Password; // скопируем в TextBox из PasswordBox
                pwdTextBox.Visibility = Visibility.Visible; // TextBox - отобразить
                pwdPasswordBox.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                pwdPasswordBox.Password = pwdTextBox.Text; // скопируем в PasswordBox из TextBox 
                pwdTextBox.Visibility = Visibility.Hidden; // TextBox - скрыть
                pwdPasswordBox.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }


        private void ReciveBySeed(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (new Mnemonic(UserSEED.Text, Wordlist.English).IsValidChecksum)
                {
                    using (var db = new CursachContext())
                    {
                        var user = db.User.FirstOrDefault(u => u.Mnemomic == UserSEED.Text);
                        if (user != null)
                        {
                            MessageBox.Show("Мы нашли вас!");
                            Application.Current.Resources["Mnenomics"] = UserSEED.Text;
                            ResetPasswordPanel.Visibility = Visibility.Visible;
                            MnemnomPanel.Visibility = Visibility.Collapsed;
                            
                        }
                        else
                        {
                            MessageBox.Show("Такого пользователя нет");
                        }
                    }
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

        private void UpdatePassword(object sender, RoutedEventArgs e)
        {
            if (pwdPasswordBox.Password != "")
            {
                try
                {
                    
                    using (var db = new CursachContext())
                    {
                        DataBase dataBase = new DataBase();
                        var PasswordHash = dataBase.HashFuncExamination(pwdPasswordBox.Password);
                        var user = db.User.Where(x => x.Mnemomic == Application.Current.Resources["Mnenomics"].ToString()).FirstOrDefault();
                        user.Password = PasswordHash;
                        db.SaveChanges();
                        MessageBox.Show("Пароль успешно обновлён!");
                        NavigationService.GoBack();
                    }
                }

                catch(Exception ex)
                {
                    MessageBox.Show("Не получилось обновить пароль" + ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Введите пароль!");
            }
        }


        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


    }

}
