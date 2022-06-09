using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kyrsach.Services
{
    public class AuthenticationService
    {
        private MailSender MainFunck = new MailSender();
        private DataBase dataBase = new DataBase();

        public bool Login(string login, string password)
        {
            Application.Current.Resources["SaveLogin"] = login;
            var PasswordHash = dataBase.HashFuncExamination(password);
            var user_login = dataBase.CheckLoginAndPassword(login, PasswordHash);

            if (user_login.Count() == 1)
            {
                Application.Current.Resources["SaveLogin"] = user_login[0].Mail;
                Application.Current.Resources["Mnenomics"] = user_login[0].Mnemomic;
                Application.Current.Resources["USER_ID"] = user_login[0].IdUser;
                Application.Current.Resources["Admin"] = user_login[0].Admin;
                MainFunck.SendEmail();
                return true;
            }
            return false;
        }

        public bool Register(string RegLogin, string passwrod, string regMail, string seed)
        {
            var PasswordHash = dataBase.HashFuncExamination(passwrod);
            using(var db = new CursachContext())
            {
                var user = db.User.Where(u => u.UserName == RegLogin).ToList();
                var userbyseed = db.User.Where(u => u.Mnemomic == seed).ToList();
                if(user.Count == 0 && userbyseed.Count == 0)
                {
                    return dataBase.RegisterInDataBase(RegLogin, PasswordHash, regMail, seed);
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином или SEED существует уже");
                    return false;
                }
            }
        }

        public bool CheckMail(string code1, string code2)
        {
            if (code1 == code2)
                return true;
            else
                return false;
        }

        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}