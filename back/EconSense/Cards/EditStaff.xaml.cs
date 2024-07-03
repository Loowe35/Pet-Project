using EconSense.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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

namespace EconSense.Cards
{
    /// <summary>
    /// Логика взаимодействия для EditStaff.xaml
    /// </summary>
    public partial class EditStaff : UserControl
    {
        int id;
        public EditStaff(int id, string Name, string Fam, string Patr, string mail, string pasport, string phone, string place, string placeNow, string pos, DateTime birth)
        {
            InitializeComponent();
            this.id = id;
            this.Fam.Text = Fam;
            this.Patr.Text = Patr;
            this.Name.Text = Name;
            this.birht.SelectedDate = birth;
            this.Pasport.Text = pasport;
            this.phone.Text = phone;
            this.Mail.Text = mail;
            this.place.Text = place;
            this.Fact_place.Text = placeNow;
            this.position.Text = pos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем объект сотрудника из базы данных по его ID
            var user = App.context.Users.FirstOrDefault(u => u.UserId == id);

            if (user != null)
            {
                // Проверка на пустые поля
                if (string.IsNullOrWhiteSpace(Name.Text) ||
                    string.IsNullOrWhiteSpace(Fam.Text) ||
                    string.IsNullOrWhiteSpace(Pasport.Text) ||
                    string.IsNullOrWhiteSpace(phone.Text) ||
                    string.IsNullOrWhiteSpace(Mail.Text) ||
                    string.IsNullOrWhiteSpace(place.Text) ||
                    string.IsNullOrWhiteSpace(Fact_place.Text) ||
                    string.IsNullOrWhiteSpace(position.Text) ||
                    birht.SelectedDate == null)
                {
                    MessageBox.Show("Все поля должны быть заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Проверяем уникальность серии и номера паспорта
                var existingPassportUser = App.context.Users.FirstOrDefault(u => u.PassportSeriesAndNumber == Pasport.Text && u.UserId != id);
                if (existingPassportUser != null)
                {
                    MessageBox.Show("Сотрудник с такой серией и номером паспорта уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Проверяем уникальность номера телефона
                var existingPhoneUser = App.context.Users.FirstOrDefault(u => u.PhoneNumber == phone.Text && u.UserId != id);
                if (existingPhoneUser != null)
                {
                    MessageBox.Show("Сотрудник с таким номером телефона уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Проверяем уникальность адреса электронной почты
                var existingEmailUser = App.context.Users.FirstOrDefault(u => u.Email == Mail.Text && u.UserId != id);
                if (existingEmailUser != null)
                {
                    MessageBox.Show("Сотрудник с таким адресом электронной почты уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DateTime? selectedDate = birht.SelectedDate;

                if (selectedDate.HasValue)
                {
                    // Рассчитываем возраст сотрудника
                    int age = DateTime.Today.Year - selectedDate.Value.Year;

                    // Проверяем, что возраст больше или равен 18
                    if (age < 18)
                    {
                        MessageBox.Show("Сотруднику должно быть не меньше 18 лет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }



                    // Обновляем свойства объекта сотрудника на основе данных из текстовых полей
                    user.FirstName = Name.Text;
                    user.LastName = Fam.Text;
                    user.Patronymic = Patr.Text;
                    user.Email = Mail.Text;
                    user.PassportSeriesAndNumber = Pasport.Text;
                    user.PhoneNumber = phone.Text;
                    user.ActualResidentialAddress = place.Text;
                    user.PlaceOfResidence = Fact_place.Text;
                    user.DateOfBirth = new DateOnly(selectedDate.Value.Year, selectedDate.Value.Month, selectedDate.Value.Day);
                    user.Position = position.Text;

                    try
                    {
                        // Сохраняем изменения в базе данных
                        App.context.SaveChanges();
                        MessageBox.Show("Информация о сотруднике успешно обновлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                        Pages.Staff staff = new Pages.Staff();
                        Classes.Navigate.Card.Navigate(staff);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при обновлении информации о сотруднике: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Сотруднику должно быть больше 18 лет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private bool ContainsDigits(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        private void Fam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (ContainsDigits(e.Text))
            {
                e.Handled = true;
                MessageBox.Show("В этом поле нельзя вставлять цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void birht_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
                e.Handled = true;
            
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

        private void birht_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }
    }
}

