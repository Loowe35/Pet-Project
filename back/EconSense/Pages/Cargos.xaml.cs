using EconSense.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cargos.xaml
    /// </summary>
    public partial class Cargos : Page
    {
        public Cargos()
        {
            InitializeComponent();
            LoadCargo();
        }

        public void LoadCargo()
        {
            List<Model.Cargo> list = App.context.Cargoes.ToList();
            CargoView.ItemsSource = list;
        }
        private void NextAfterCargo_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Volume.Text) || string.IsNullOrWhiteSpace(Weight.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (Volume.Text.Contains('.'))
            {
                Volume.Text = Volume.Text.Replace('.', ',');
                Volume.SelectionStart = Volume.Text.Length;
            }
            if (Weight.Text.Contains('.'))
            {
                Weight.Text = Weight.Text.Replace('.', ',');
                Weight.SelectionStart = Weight.Text.Length;
            }

            Model.Cargo newCargo = new Model.Cargo
            {
                CargoName = Name.Text,
                Volume = decimal.Parse(Volume.Text),
                Weight = decimal.Parse(Weight.Text),
               
            };
            App.context.Cargoes.Add(newCargo);
            App.context.SaveChanges();
            LoadCargo();
            Classes.ID.idCargo = newCargo.CargoId;
            MessageBox.Show("Груз успешно выбран!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            Pages.Route route = new Pages.Route();
            Classes.Navigate.Card.Navigate(route);
            Name.Clear();
            Volume.Clear();
            Weight.Clear();
        }

        private void CargoView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CargoView.SelectedItem != null)
            {
                Model.Cargo selectedCargo = (Model.Cargo)CargoView.SelectedItem;
                Classes.ID.idCargo = selectedCargo.CargoId;

                Pages.Route route = new Pages.Route();
                Classes.Navigate.Card.Navigate(route);
            }
        }

        private void Volume_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя пиcать буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Weight_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void Volume_Pasting(object sender, DataObjectPastingEventArgs e)
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

        private void Weight_Pasting(object sender, DataObjectPastingEventArgs e)
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
    }
}
