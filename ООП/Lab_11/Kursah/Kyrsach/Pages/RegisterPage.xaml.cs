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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kyrsach
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        Class1 MainFunc = new Class1();
        DataBase dataBase = new DataBase();
        bool flag = false;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["SaveLogin"] = RegMail.Text;
            MainFunc.SendEmail();
            CheckMailCode.Visibility = Visibility.Visible;
            CheckMailCode2.Visibility = Visibility.Visible;
            CheckMail.Visibility = Visibility.Hidden;
            CheckMailCodey.Visibility = Visibility.Visible;
            CheckMailCodey.Visibility = Visibility.Visible;

        }
        private void CheckMailCode3(object sender, RoutedEventArgs e)
        {
            if (CheckMailCode.Text == App.Current.Resources["Code"].ToString())
            {
                flag = true;
                MessageBox.Show("Почта подтверждена");
                CheckMailCodey.Visibility = Visibility.Hidden;
                CheckMail2.Visibility = Visibility.Visible;
            }
            else 
            { 
                flag = false;
                MessageBox.Show("Неверный код");
            };

        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            CheckMail.Visibility = Visibility.Hidden;
            DateTime now = DateTime.Now;

            DateTime date = RegDate.DisplayDate;
            int Year = now.Year - date.Year;
            if (Year >= 18)
            {
                if (flag)
                {
                    string PasswordHash = dataBase.HashFuncExamination(RegPWDPasswordBox.Password);

                    string querystring = $"insert into users(loginID, password, mail, date) values('{RegLogin.Text}','{PasswordHash}','{RegMail.Text}','{date}')";
                    SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
                    dataBase.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Аккаунт зарегестрирован");
                        dataBase.closeConnection();
                        NavigationService.Navigate(new Page1());
                    }
                    else { MessageBox.Show("Аккаунт не зарегестрирован"); }
                }
                else
                {
                    CheckMail.Visibility = Visibility.Hidden;
                }
            }
            else { MessageBox.Show("Вам нет 18"); }
           
        }
        
    }
}
