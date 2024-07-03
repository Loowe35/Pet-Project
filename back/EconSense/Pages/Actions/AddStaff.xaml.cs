using EconSense.Model;
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

namespace EconSense.Pages.Actions
{
    /// <summary>
    /// Логика взаимодействия для AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Page
    {
        public AddStaff()
        {
            InitializeComponent();
            
        }

        private void Fam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if ((inp < 'А' || inp > 'Я') & (inp < 'а' || inp > 'я'))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя писать цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя пиcать буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Fam.Text) ||
        string.IsNullOrWhiteSpace(Name.Text) ||
        string.IsNullOrWhiteSpace(Patr.Text) ||
        string.IsNullOrWhiteSpace(Pasport.Text) ||
        string.IsNullOrWhiteSpace(phone.Text) ||
        string.IsNullOrWhiteSpace(Mail.Text) ||
        string.IsNullOrWhiteSpace(place.Text) ||
        string.IsNullOrWhiteSpace(Fact_place.Text) ||
        birht.SelectedDate == null ||
        string.IsNullOrWhiteSpace(Login.Text) ||
        string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DateTime selectedDate = birht.SelectedDate.Value;
            DateTime now = DateTime.Now;
            int age = now.Year - selectedDate.Year;
            if (now < selectedDate.AddYears(age)) age--;

            if (age < 18)
            {
                MessageBox.Show("Возраст сотрудника должен быть не менее 18 лет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingPassportUser = App.context.Users.FirstOrDefault(u => u.PassportSeriesAndNumber == Pasport.Text);
            if (existingPassportUser != null)
            {
                MessageBox.Show("Сотрудник с такой серией и номером паспорта уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingPhoneUser = App.context.Users.FirstOrDefault(u => u.PhoneNumber == phone.Text);
            if (existingPhoneUser != null)
            {
                MessageBox.Show("Сотрудник с таким номером телефона уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var existingEmailUser = App.context.Users.FirstOrDefault(u => u.Email == Mail.Text);
            if (existingEmailUser != null)
            {
                MessageBox.Show("Сотрудник с таким адресом электронной почты уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var Status = App.context.Users.FirstOrDefault(u => u.Login == Login.Text);

            if (Status != null)
            {
                if (Status.Status == "Работает")
                {
                    MessageBox.Show("Сотрудник с таким логином уже существует и работает!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            var newUser = new User
            {
                LastName = Fam.Text,
                FirstName = Name.Text,
                Patronymic = Patr.Text,
                DateOfBirth = birht.SelectedDate.HasValue ? new DateOnly(birht.SelectedDate.Value.Year, birht.SelectedDate.Value.Month, birht.SelectedDate.Value.Day) : null,
                PassportSeriesAndNumber = Pasport.Text,
                PlaceOfResidence = Fact_place.Text,
                ActualResidentialAddress = place.Text,
                PhoneNumber = phone.Text,
                Email = Mail.Text,
                Login = Login.Text,
                Password = Password.Text,
                Position = (position.SelectedItem as ComboBoxItem)?.Content?.ToString(),
                Status = "Работает" 
            };

            try
            {
                App.context.Users.Add(newUser);
                App.context.SaveChanges();
                MessageBox.Show("Сотрудник успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Fam.Clear();
                Name.Clear();
                Patr.Clear();
                birht.SelectedDate = null;
                Pasport.Clear();
                Fact_place.Clear();
                place.Clear();
                phone.Clear();
                Mail.Clear();
                Login.Clear();
                Password.Clear();
                position.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
        private void Fam_Pasting(object sender, DataObjectPastingEventArgs e)
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

        private void Name_Pasting(object sender, DataObjectPastingEventArgs e)
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

        private void birht_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
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

        private void phone_Pasting(object sender, DataObjectPastingEventArgs e)
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

        private void birht_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }
    }
}
