using MaterialDesignColors;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для Drivers.xaml
    /// </summary>
    public partial class Drivers : Page
    {
        
        public Drivers()
        {
            InitializeComponent();
            LoadDrivers();
        }
        private void LoadDrivers()
        {

            List<Model.Driver> list = App.context.Drivers.ToList();
            string searchText = Search.Text.ToLower();

            list = list.Where(d =>
                d.FirstName.ToLower().Contains(searchText) ||
                d.LastName.ToLower().Contains(searchText) ||
                d.Patronymic.ToLower().Contains(searchText)
            ).ToList();

            DriversView.ItemsSource = list;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchView.Visibility = Visibility.Collapsed;
            AddView.Visibility = Visibility.Visible;
            LoginLab.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            PasswordLab.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Visible;
        }

        private bool isUserSelection = true;

        private void DriversView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isUserSelection)
            {
                SearchView.Visibility = Visibility.Collapsed;
                AddView.Visibility = Visibility.Visible;
                Model.Driver selectedDriver = (Model.Driver)DriversView.SelectedItem;
                if (selectedDriver != null)
                {
                    LastName.Text = selectedDriver.LastName;
                    FirstName.Text = selectedDriver.FirstName;
                    Patr.Text = selectedDriver.Patronymic;
                    Pasport.Text = selectedDriver.PassportSeriesAndNumber;
                    Phone.Text = selectedDriver.PhoneNumber;
                    Mail.Text = selectedDriver.Email;
                    if (selectedDriver.DrivingLicenseExpiryDate.HasValue)
                    {
                        DateTime licenseExpiryDateTime = new DateTime(selectedDriver.DrivingLicenseExpiryDate.Value.Year,
                                                                      selectedDriver.DrivingLicenseExpiryDate.Value.Month,
                                                                      selectedDriver.DrivingLicenseExpiryDate.Value.Day);
                        Date.SelectedDate = licenseExpiryDateTime;
                    }
                    Classes.ID.idDrivers=selectedDriver.DriverId;
                    Login.Visibility = Visibility.Collapsed;
                    LoginLab.Visibility = Visibility.Collapsed;
                    Password.Visibility = Visibility.Collapsed;
                    PasswordLab.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void ClearFields()
        {
            LastName.Text = "";
            FirstName.Text = "";
            Patr.Text = "";
            Pasport.Text = "";
            Phone.Text = "";
            Mail.Text = "";
            Date.SelectedDate = null;
            Login.Text = "";
            Password.Text = "";
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddView.Visibility = Visibility.Collapsed;
            SearchView.Visibility = Visibility.Visible;
            isUserSelection = false;
            DriversView.SelectedIndex = -1;
            isUserSelection = true;
            ClearFields();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (DriversView.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(LastName.Text) ||
                    string.IsNullOrWhiteSpace(FirstName.Text) ||
                    string.IsNullOrWhiteSpace(Pasport.Text) ||
                    string.IsNullOrWhiteSpace(Phone.Text) ||
                    string.IsNullOrWhiteSpace(Mail.Text) ||
                    Date.SelectedDate == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                Model.Driver selectedDriver = (Model.Driver)DriversView.SelectedItem;

                if (App.context.Drivers.Any(driver => driver.Login == Login.Text && driver.DriverId != selectedDriver.DriverId))
                {
                    MessageBox.Show("Логин уже занят!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (App.context.Drivers.Any(driver => driver.Email == Mail.Text && driver.DriverId != selectedDriver.DriverId))
                {
                    MessageBox.Show("Почта уже занята!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (App.context.Drivers.Any(driver => driver.PassportSeriesAndNumber == Pasport.Text && driver.DriverId != selectedDriver.DriverId))
                {
                    MessageBox.Show("Серия и номер паспорта уже заняты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (App.context.Drivers.Any(driver => driver.PhoneNumber == Phone.Text && driver.DriverId != selectedDriver.DriverId))
                {
                    MessageBox.Show("Номер телефона уже занят!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Date.SelectedDate < DateTime.Today)
                {
                    MessageBox.Show("Дата не может быть в прошлом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Phone.Text.Length < 11)
                {
                    MessageBox.Show("Номер телефона должен содержать не менее 11 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Pasport.Text.Length < 10)
                {
                    MessageBox.Show("Серия и номер паспорта должны содержать не менее 10 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                selectedDriver.LastName = LastName.Text;
                selectedDriver.FirstName = FirstName.Text;
                selectedDriver.Patronymic = Patr.Text;
                selectedDriver.PassportSeriesAndNumber = Pasport.Text;
                selectedDriver.PhoneNumber = Phone.Text;
                selectedDriver.Email = Mail.Text;
                DateOnly licenseExpiryDateOnly = new DateOnly(selectedDriver.DrivingLicenseExpiryDate.Value.Year,
                                                                           selectedDriver.DrivingLicenseExpiryDate.Value.Month,
                                                                           selectedDriver.DrivingLicenseExpiryDate.Value.Day);
                App.context.SaveChanges();
                LoadDrivers();
                MessageBox.Show("Водитель успешно отредактиован!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AddView.Visibility = Visibility.Collapsed;
                SearchView.Visibility = Visibility.Visible;
                isUserSelection = false;
                DriversView.SelectedIndex = -1;
                isUserSelection = true;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(LastName.Text) ||
                    string.IsNullOrWhiteSpace(FirstName.Text) ||
                    string.IsNullOrWhiteSpace(Pasport.Text) ||
                    string.IsNullOrWhiteSpace(Phone.Text) ||
                    string.IsNullOrWhiteSpace(Mail.Text) ||
                    Date.SelectedDate == null ||
                    string.IsNullOrWhiteSpace(Login.Text) ||
                    string.IsNullOrWhiteSpace(Password.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (App.context.Drivers.Any(driver => driver.Login == Login.Text))
                {
                    MessageBox.Show("Логин уже занят!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (App.context.Drivers.Any(driver => driver.Email == Mail.Text))
                {
                    MessageBox.Show("Почта уже занята!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (App.context.Drivers.Any(driver => driver.PassportSeriesAndNumber == Pasport.Text))
                {
                    MessageBox.Show("Серия и номер паспорта уже заняты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (App.context.Drivers.Any(driver => driver.PhoneNumber == Phone.Text))
                {
                    MessageBox.Show("Номер телефона уже занят!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (App.context.Drivers.Any(driver => driver.PhoneNumber == Phone.Text))
                {
                    MessageBox.Show("Номер телефона уже занят!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Date.SelectedDate < DateTime.Today)
                {
                    MessageBox.Show("Дата не может быть в прошлом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Phone.Text.Length < 11)
                {
                    MessageBox.Show("Номер телефона должен содержать не менее 11 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Pasport.Text.Length < 10)
                {
                    MessageBox.Show("Серия и номер паспорта должны содержать не менее 10 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Model.Driver newDriver = new Model.Driver
                {
                    LastName = LastName.Text,
                    FirstName = FirstName.Text,
                    Patronymic = Patr.Text,
                    PassportSeriesAndNumber = Pasport.Text,
                    PhoneNumber = Phone.Text,
                    Email = Mail.Text,
                    DrivingLicenseExpiryDate = Date.SelectedDate.HasValue ? new DateOnly(Date.SelectedDate.Value.Year, Date.SelectedDate.Value.Month, Date.SelectedDate.Value.Day) : null,
                    Login = Login.Text,
                    Password = Password.Text
                };
                if (string.IsNullOrWhiteSpace(Mail.Text) || !IsValidEmail(Mail.Text))
                {
                    MessageBox.Show("Пожалуйста, введите корректный адрес электронной почты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (DriversView.SelectedItem == null && !string.IsNullOrWhiteSpace(Mail.Text))
                {
                    string subject = "Добро пожаловать в нашу систему!";
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
                                "<h1>Добро пожаловать!</h1>" +
                                "<h1>" + FirstName.Text + " " + Patr.Text+"</h1>" +
                                "<p>Ваш логин: " + Login.Text + "</p>" +
                                "<p>Ваш пароль: " + Password.Text + "</p>" +
                            "</div>" +
                            "<div class='footer'>" +
                                "<p>С уважением, Администрация EconSense</p>" +
                            "</div>" +
                        "</body>" +
                        "</html>";

                    bool emailSent = SendEmail(Mail.Text, subject, body);

                    if(emailSent)
                    {
                        App.context.Drivers.Add(newDriver);
                        App.context.SaveChanges();
                        MessageBox.Show("Водитель успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadDrivers();

                        AddView.Visibility = Visibility.Collapsed;
                        SearchView.Visibility = Visibility.Visible;
                        isUserSelection = false;
                        DriversView.SelectedIndex = -1;
                        isUserSelection = true;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при отправке письма. Водитель не был добавлен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool SendEmail(string toAddress, string subject, string body)
        {
            if (!IsValidEmail(toAddress))
            {
                MessageBox.Show("Некорректный адрес электронной почты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!toAddress.EndsWith("@yandex.ru"))
            {
                MessageBox.Show("Поддерживается отправка только на почту яндекс!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; 
            }
            string fromAddress = "Shakirov.mmm@yandex.ru";
            string password = "bckeskzqmgddilwl";

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

            try
            {
                smtp.Send(mail);
                MessageBox.Show("Письмо успешно отправлено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке письма: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        private void Search_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            LoadDrivers();
        }

        private void LastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if ((inp < 'А' || inp > 'Я') & (inp < 'а' || inp > 'я'))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя писать цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if ((inp < 'А' || inp > 'Я') & (inp < 'а' || inp > 'я'))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя писать цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Patr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if ((inp < 'А' || inp > 'Я') & (inp < 'а' || inp > 'я'))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя писать цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Pasport_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя пиcать буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя пиcать буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool IsRussian(string text)
        {
            foreach (char c in text)
            {
                if (!(c >= 'А' && c <= 'я') && c != 'Ё' && c != 'ё' && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsDigit(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private void LastName_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsRussian(pastedText))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Можно вставлять только буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        TextBox textBox = (TextBox)sender;
                        textBox.Text = string.Empty;
                    }));
                    e.CancelCommand();
                }
            }
        }

        private void FirstName_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsRussian(pastedText))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Можно вставлять только буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        TextBox textBox = (TextBox)sender;
                        textBox.Text = string.Empty;
                    }));
                    e.CancelCommand();
                }
            }
        }

        private void Patr_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsRussian(pastedText))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Можно вставлять только буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        TextBox textBox = (TextBox)sender;
                        textBox.Text = string.Empty;
                    }));
                    e.CancelCommand();
                }
            }
        }

        private void Pasport_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsDigit(pastedText))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Можно вставлять только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        TextBox textBox = (TextBox)sender;
                        textBox.Text = string.Empty;
                    }));
                    e.CancelCommand();
                }
            }
        }

        private void Phone_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsDigit(pastedText))
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Можно вставлять только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        TextBox textBox = (TextBox)sender;
                        textBox.Text = string.Empty;
                    }));
                    e.CancelCommand();
                }
            }
        }

        private void Date_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private void Date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }
    }
}

