using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Text.RegularExpressions;

namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для transport_vehicle.xaml
    /// </summary>
    public partial class transport_vehicle : Page
    {
        public transport_vehicle()
        {
            InitializeComponent();
            LoadTransport();
        }
        public void LoadTransport()
        {
            List<Model.Transport> list = App.context.Transports.ToList();
            TransportView.ItemsSource = list;
        }
        private void Search_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            LoadTransport();
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

        private void ClearFields()
        {
            Brand.Text = "";
            Model.Text = "";
            Volume.Text = "";
            Average.Text = "";
            Plate.Text = "";
            Date.SelectedDate = null;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddView.Visibility = Visibility.Collapsed;
            SearchView.Visibility = Visibility.Visible;
            isUserSelection = false;
            TransportView.SelectedIndex = -1;
            isUserSelection = true;
            ClearFields();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            if (TransportView.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(Brand.Text) ||
                    string.IsNullOrWhiteSpace(Model.Text) ||
                    string.IsNullOrWhiteSpace(Average.Text) ||
                    Plate.Text == Mask ||
                    string.IsNullOrWhiteSpace(Volume.Text) ||
                    Date.SelectedDate == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                Model.Transport selectedTransport = (Model.Transport)TransportView.SelectedItem;


                if (App.context.Transports.Any(t => t.LicensePlate == Plate.Text && t.TransportId != selectedTransport.TransportId))
                {
                    MessageBox.Show("Гос. номер уже используется!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Volume.Text.Contains('.'))
                {
                    Volume.Text = Volume.Text.Replace('.', ',');
                    Volume.SelectionStart = Volume.Text.Length;
                }
                if (Average.Text.Contains('.'))
                {
                    Average.Text = Average.Text.Replace('.', ',');
                    Average.SelectionStart = Average.Text.Length;
                }
                if (Date.SelectedDate > DateTime.Today)
                {
                    MessageBox.Show("Дата не может быть в будущем!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                selectedTransport.Brand = Brand.Text;
                selectedTransport.Model = Model.Text;
                selectedTransport.LicensePlate = Plate.Text.ToUpper();
                selectedTransport.BodyVolume = string.IsNullOrWhiteSpace(Volume.Text) ? null : decimal.Parse(Volume.Text);
                selectedTransport.AverageFuelConsumption = string.IsNullOrWhiteSpace(Average.Text) ? null : decimal.Parse(Average.Text);


                DateOnly licenseExpiryDateOnly = new DateOnly(selectedTransport.YearOfRelease.Value.Year,
                                                                           selectedTransport.YearOfRelease.Value.Month,
                                                                           selectedTransport.YearOfRelease.Value.Day);
                App.context.SaveChanges();
                LoadTransport();
                MessageBox.Show("Обновлено!");
                TransportView.SelectedItem = null;
                AddView.Visibility = Visibility.Collapsed;
                SearchView.Visibility = Visibility.Visible;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Brand.Text) ||
                    string.IsNullOrWhiteSpace(Model.Text) ||
                    string.IsNullOrWhiteSpace(Average.Text) ||
                    Plate.Text == Mask ||
                    string.IsNullOrWhiteSpace(Volume.Text) ||
                    Date.SelectedDate == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (App.context.Transports.Any(t => t.LicensePlate == Plate.Text))
                {
                    MessageBox.Show("Гос. номер уже используется!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Volume.Text.Contains('.'))
                {
                    Volume.Text = Volume.Text.Replace('.', ',');
                    Volume.SelectionStart = Volume.Text.Length;
                }
                if (Average.Text.Contains('.'))
                {
                    Average.Text = Average.Text.Replace('.', ',');
                    Average.SelectionStart = Average.Text.Length;
                }
                if (Date.SelectedDate > DateTime.Today)
                {
                    MessageBox.Show("Дата не может быть в будущем!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Model.Transport newTransport = new Model.Transport
                {
                    Brand = Brand.Text,
                    Model = Model.Text,
                    BodyVolume = decimal.Parse(Volume.Text),
                    AverageFuelConsumption = decimal.Parse(Average.Text),
                    LicensePlate = Plate.Text.ToUpper(),
                    YearOfRelease = Date.SelectedDate.HasValue ? new DateOnly(Date.SelectedDate.Value.Year, Date.SelectedDate.Value.Month, Date.SelectedDate.Value.Day) : null,

                };

                App.context.Transports.Add(newTransport);
                App.context.SaveChanges();

                LoadTransport();
                MessageBox.Show("Транспортное средство добалено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                TransportView.SelectedItem = null;
                AddView.Visibility = Visibility.Collapsed;
                SearchView.Visibility = Visibility.Visible;
                isUserSelection = false;
                TransportView.SelectedIndex = -1;
                isUserSelection = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchView.Visibility = Visibility.Collapsed;
            AddView.Visibility = Visibility.Visible;
            Plate.Text = Mask;
            Plate.Foreground = Brushes.Gray;
        }

        private bool isUserSelection = true;
        private void TransportView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isUserSelection)
            {
                SearchView.Visibility = Visibility.Collapsed;
                AddView.Visibility = Visibility.Visible;
                Model.Transport selectedTransport = (Model.Transport)TransportView.SelectedItem;
                if (selectedTransport != null)
                {
                    Model.Text = selectedTransport.Model;
                    Brand.Text = selectedTransport.Brand;
                    Plate.Text = selectedTransport.LicensePlate;
                    Volume.Text = selectedTransport.BodyVolume.HasValue ? selectedTransport.BodyVolume.Value.ToString() : string.Empty;
                    Average.Text = selectedTransport.AverageFuelConsumption.HasValue ? selectedTransport.AverageFuelConsumption.Value.ToString() : string.Empty;
                    Plate.Foreground = Brushes.Black;

                    if (selectedTransport.YearOfRelease.HasValue)
                    {
                        DateTime licenseExpiryDateTime = new DateTime(selectedTransport.YearOfRelease.Value.Year,
                                                                      selectedTransport.YearOfRelease.Value.Month,
                                                                      selectedTransport.YearOfRelease.Value.Day);
                        Date.SelectedDate = licenseExpiryDateTime;
                    }
                    Classes.ID.idTransport = selectedTransport.TransportId;
                   
                }
            }
        }

        private int letterCount = 0;
        private int digitCount = 0;
        private void Plate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string currentText = (sender as TextBox).Text;

            int currentLength = currentText.Length;
            char inp = e.Text[0];
            string allowedLetters = "АВЕКМНОРСТУХавекмнорстух";

            if (currentLength == 0)
            {
                if (char.IsLetter(inp) && allowedLetters.Contains(inp))
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Можно вводить только А, В, Е, К, М, Н, О, Р, С, Т, У и Х!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            else if (currentLength == 1)
            {
                if (Char.IsDigit(e.Text, 0))
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (currentLength == 2)
            {
                if (Char.IsDigit(e.Text, 0))
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }

            else if (currentLength == 3)
            {
                if (Char.IsDigit(e.Text, 0))
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }

            else if (currentLength == 4)
            {
                if (char.IsLetter(inp) && allowedLetters.Contains(inp))
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (currentLength == 5)
            {
                if (char.IsLetter(inp) && allowedLetters.Contains(inp))
                {
                    return;
                }
                else
                {
                    e.Handled = true;
                    return;
                }
            }

            else
            {
                e.Handled = true;
                return;
            }

        }
        private string Mask = "А000АА";

        private void Plate_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == Mask)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void Plate_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = Mask;
            textBox.Foreground = Brushes.Gray;
        }

        private void Plate_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = Mask;
                textBox.Foreground = Brushes.Gray;
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
