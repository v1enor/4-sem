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
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using Kyrsach.Pages;

namespace Kyrsach
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Class1 MainFunck = new Class1();
        DataBase dataBase = new DataBase();

        public Page1()
        {

            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Login.Text.Length > 0)
            {
                if (pwdPasswordBox.Password.Length > 0)
                {


                    App.Current.Resources["SaveLogin"] = Login.Text;
                    string PasswordHash = dataBase.HashFuncExamination(pwdPasswordBox.Password);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string querystring = $"select userID, loginID, password, mail, date from users where loginID = '{Login.Text}' and password = '{PasswordHash}'";
                    SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if (table.Rows.Count == 1)
                    {
                        App.Current.Resources["SaveLogin"] = table.Rows[0][3].ToString();
                        MainFunck.SendEmail();
                        NavigationService.Navigate(new Page2());
                        
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль неверные!");
                    }
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }
        //public string HashFuncExamination(string source)
        //{
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        string hash = Hash.GetHash(sha256Hash, source);

        //        //MessageBox.Show($"Хэш SHA256 строки {source} равен: {hash}.");
        //        //Login.Text = hash.ToString();
        //        return hash;
        //        //MessageBox.Show("Проверка хэша...");

        //        //if (Hash.VerifyHash(sha256Hash, source, hash))
        //        //{
        //        //    MessageBox.Show("Хэши одинаковые.");
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("Хэши не совпадают.");
        //        //}
        //    }
        //}
        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
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
    }
}
