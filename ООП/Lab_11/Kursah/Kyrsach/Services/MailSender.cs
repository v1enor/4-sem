using System;
using System.Windows;
using System.Net.Mail;
using System.Net;

namespace Kyrsach
{
    public class MailSender
    {
        private Random rand = new Random();
        public int code;
        public string SaveLog;

        public void SendEmail()
        {
            code = rand.Next(1000, 9999);
            //code = 1;
            Application.Current.Resources["Code"] = code;


            var mail = new MailMessage();
            mail.From = new MailAddress("cwalletinfo@yandex.by");
            mail.To.Add(Application.Current.Resources["SaveLogin"].ToString());
            mail.Subject = "Код для авторизации";
            mail.Body = "Используйте этот код для авторизации в приложеие: " + code.ToString();

            var SmtpServer = new SmtpClient();
            SmtpServer.Host = "smtp.yandex.ru";
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.Credentials = new NetworkCredential("cwalletinfo@yandex.by", "iuppfdiexzxjjorb");


            try
            {
                SmtpServer.Send(mail);
                MessageBox.Show("Письмо отправлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отправки письма");
            }

        }

        public void SendNotification(TransactionsList trans)
        {

            var mail = new MailMessage();
            mail.From = new MailAddress("cwalletinfo@yandex.by");
            mail.To.Add(Application.Current.Resources["SaveLogin"].ToString());

            mail.Subject = "Код для авторизации";

            mail.Body = "Совершен перевод на сумму: " + trans.Amount.ToString() + "\n";
            mail.Body += "С адреса: " + trans.FromAdress.ToString() + "\n";
            mail.Body += "На адрес: " + trans.ToAdress.ToString() + "\n";
            mail.Body += "Дата: " + trans.Date.ToString() + "\n";
            mail.Body += "Комисия: " + trans.Fee.ToString() + "\n";
            mail.Body += "Цена в USD: " + trans.UsdPrice.ToString() + "\n";
            mail.Body += "Спасибо что вы с нами!";


            var SmtpServer = new SmtpClient();
            SmtpServer.Host = "smtp.yandex.ru";
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            SmtpServer.Credentials = new NetworkCredential("cwalletinfo@yandex.by", "iuppfdiexzxjjorb");

            try
            {
                SmtpServer.Send(mail);
                MessageBox.Show("Информация о транзакции отправлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отправки письма");
            }
        }

    }

}