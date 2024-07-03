using EconSense.Classes;
using EconSense.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для Route.xaml
    /// </summary>
    public partial class Route : Page
    {
        public Route()
        {
            InitializeComponent();
            Loaded += ViewRour_Loaded;
            Unloaded += ViewRour_Unloaded;
            ClearRoadFields();
        }
        private void ViewRour_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoute();
        }
        private void ViewRour_Unloaded(object sender, RoutedEventArgs e)
        {
            // Присваиваем переменной null при выгрузке страницы
            RouteFullView.ItemsSource = null;
        }
        private void ClearRoadFields()
        {
            NameRoad.Text = string.Empty;
            length.Text = string.Empty;
            arrival.Text = string.Empty;
        }
        public class RouteData
        {
            public string RouteName { get; set; }
            public string StartingPoint { get; set; }
            public string EndingPoint { get; set; }
            public string RoadName { get; set; }
            public decimal RoadLength { get; set; }
            public string ArrivalPoint { get; set; }
        }
        public void LoadRoute()
        {
            RouteFullView.Items.Clear();
            var queryResult = (from r in App.context.Routes
                               join rs in App.context.RouteSections on r.RouteId equals rs.RouteNumber
                               join rd in App.context.Roads on rs.RoadNumber equals rd.RoadId
                               where r.RouteId == Classes.ID.idRoute
                               select new RouteData
                               {
                                   RouteName = r.RouteName,
                                   StartingPoint = r.StartingPoint,
                                   EndingPoint = r.EndingPoint,
                                   RoadName = rd.RoadName,
                                   RoadLength = rd.RoadLength.GetValueOrDefault(),
                                   ArrivalPoint = rd.ArrivalPoint
                               }).ToList();

            foreach (var item in queryResult)
            {
                RouteFullView.Items.Add(item);
            }
        }
        private void SaveRoute_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Start.Text) ||
                string.IsNullOrWhiteSpace(End.Text) || string.IsNullOrWhiteSpace(Dlina.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (Dlina.Text.Contains('.'))
            {
                Dlina.Text = Dlina.Text.Replace('.', ',');
                Dlina.SelectionStart = Dlina.Text.Length;
            }
            Model.Route newRoute = new Model.Route
            {
                RouteName = Name.Text,
                StartingPoint = Start.Text,
                EndingPoint = End.Text,
                RouteLength = decimal.Parse(Dlina.Text)
            };

            try
            {
                
                App.context.Routes.Add(newRoute);
                App.context.SaveChanges();
                Classes.ID.idRoute = newRoute.RouteId;
                RoutHide.Visibility= Visibility.Collapsed;
                SaveRoute.Visibility= Visibility.Collapsed;
                SaveRoad.Visibility= Visibility.Visible;
                RoadHide.Visibility= Visibility.Visible;
                MessageBox.Show("Маршрут успешно сохранен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении маршрута: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveRoad_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameRoad.Text) || string.IsNullOrWhiteSpace(length.Text) ||
                string.IsNullOrWhiteSpace(arrival.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (length.Text.Contains('.'))
            {
                length.Text = length.Text.Replace('.', ',');
                length.SelectionStart = length.Text.Length;
            }
            Model.Road newRoad = new Model.Road
            {
                RoadName = Name.Text,
                RoadLength = decimal.Parse(length.Text),
                ArrivalPoint = arrival.Text
            };

            try
            {
                
                App.context.Roads.Add(newRoad);
                App.context.SaveChanges();
                Model.RouteSection routeSection = new Model.RouteSection
                {
                    RoadNumber = newRoad.RoadId,
                    RouteNumber = Classes.ID.idRoute
                };
                App.context.RouteSections.Add(routeSection);
                App.context.SaveChanges();
                Choose.Visibility= Visibility.Visible;
                LoadRoute();

                MessageBox.Show("Дорога успешно добавлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении маршрута: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            Pages.Choose choose = new Pages.Choose();
            Classes.Navigate.Card.Navigate(choose);
            ClearRoadFields();
        }

        private void Dlina_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя пиcать буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void length_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                MessageBox.Show("В этой строке нельзя пиcать буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void Dlina_Pasting(object sender, DataObjectPastingEventArgs e)
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

        private void length_Pasting(object sender, DataObjectPastingEventArgs e)
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
