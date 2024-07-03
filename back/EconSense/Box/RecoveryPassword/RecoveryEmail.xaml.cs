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
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using EconSense.Model;
namespace EconSense.Box.RecoveryPassword
{
    /// <summary>
    /// Логика взаимодействия для RecoveryEmail.xaml
    /// </summary>
    public partial class RecoveryEmail : Window
    {
        public RecoveryEmail()
        {
            InitializeComponent();
            User user = App.context.Users.FirstOrDefault(u => u.UserId == Classes.ID.IDRecovery);
            FIO.Content = user.LastName + " " + user.FirstName;
        }
        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = App.context.Users.FirstOrDefault(u => u.UserId == Classes.ID.IDRecovery && u.Email == Email.Text && u.Status == "Работает");



            if (user != null && user.Email.Equals(Email.Text, StringComparison.OrdinalIgnoreCase))
            {

                if (NewPassword.Text == NewPasswordAgain.Text)
                {

                    user.Password = NewPassword.Text;

                    try
                    {


                        string fromAddress = "Shakirov.mmm@yandex.ru";
                        string password = "bckeskzqmgddilwl";
                        string toAddress = user.Email;
                        string subject = "Оповещение системы безопасности для аккаунта";

                        string body = "<html>" +
               "<head>" +
                   "<style>" +
                       "body {" +
                           "font-family: Arial, sans-serif;" +
                           "background-color: #f0f0f0;" +
                       "}" +
                       ".container {" +
                           "max-width: 600px;" +
                           "margin: 0 auto;" +
                           "padding: 20px;" +
                           "background-color: #ffffff;" +
                           "border-radius: 10px;" +
                           "box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);" +
                       "}" +
                       "h1 {" +
                           "color: #333333;" +
                       "}" +
                       "p {" +
                           "color: #666666;" +
                       "}" +
                       "img{\r\n            width: 600px;\r\n        }" +
                       ".footer {" +
                           "margin-top: 20px;" +
                           "text-align: center;" +
                           "color: #999999;" +
                           "font-size: 12px;" +
                       "}" +
                   "</style>" +
               "</head>" +
               "<body>" +
                   "<div class='container'>" +
                   "<img src=\"https://роско68.рф/images/15739fba5ff957936938c7fdf05f163f.webp\" alt=\"\">" +
                       "<h1>Сброс пароля</h1>" +
                       "<p>Уважаемый(ая) " + user.FirstName + " " + user.Patronymic + ", ваш пароль был успешно обновлен!</p>" +
                       "<p>Логин: " + user.Login + "</p>" +
                       "<p>Новый пароль: " + NewPassword.Text + "</p>" +
                   "</div>" +
                   "<div class='footer'>" +
                       "<p>С уважением, Администрация EconSense</p>" +
                   "</div>" +
               "</body>" +
               "</html>";

                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(fromAddress, "Администрация EconSense");
                        mail.To.Add(toAddress);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;


                        SmtpClient smtp = new SmtpClient("smtp.yandex.ru");
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(fromAddress, password);
                        smtp.EnableSsl = true;


                        smtp.Send(mail);
                        App.context.SaveChanges();
                        MessageBox.Show("Пароль успешно сброшен и обновлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при обновлении пароля: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введенные пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Почта не совпадает!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
