using EconSense.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для Choose.xaml
    /// </summary>
    public partial class Choose : Page
    {
        private Waybill waybill;
        public Choose()
        {
            InitializeComponent();
        }

        private void ChooseDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDateTime = StartWayb.SelectedDate ?? DateTime.MinValue;
            DateTime endDateTime = EndWayb.SelectedDate ?? DateTime.MaxValue;

            DateOnly startDate = new DateOnly(startDateTime.Year, startDateTime.Month, startDateTime.Day);
            DateOnly endDate = new DateOnly(endDateTime.Year, endDateTime.Month, endDateTime.Day);


            if (startDateTime >= endDateTime)
            {
                MessageBox.Show("Дата отправки должна быть меньше даты прибытия!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            waybill = new Waybill
            {
                DepartureDate = startDate, 
                ArrivalDate = endDate,
                RouteNumber = Classes.ID.idRoute,
                CargoNumber = Classes.ID.idCargo,
                UserNumber = Classes.ID.IDUser
            };

            try
            {
                App.context.Waybills.Add(waybill);
                App.context.SaveChanges();
                MessageBox.Show("успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Classes.ID.idWayb = waybill.WaybillId;
                LoadDataAsync(startDateTime, endDateTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Подробности: {ex.InnerException.Message}");
                }
            }
        }

        private async Task LoadDataAsync(DateTime startDateTime, DateTime endDateTime)
        {
            await App.context.Drivers.LoadAsync();
            await App.context.Transports.LoadAsync();

            var drivers = GetDrivers(startDateTime, endDateTime);
            var transport = GetTransport(startDateTime, endDateTime);

            Drivers.ItemsSource = drivers.ToList();
            Transport.ItemsSource = transport.ToList();

            Drivers.Columns.Clear();
            Drivers.Columns.Add(new DataGridTextColumn
            {
                Header = "Фамилия",
                Binding = new Binding("LastName")
            });
            Drivers.Columns.Add(new DataGridTextColumn
            {
                Header = "Имя",
                Binding = new Binding("FirstName")
            });
            Drivers.Columns.Add(new DataGridTextColumn
            {
                Header = "Отчество",
                Binding = new Binding("Patronymic")
            });

            Transport.Columns.Clear();
            Transport.Columns.Add(new DataGridTextColumn
            {
                Header = "Марка",
                Binding = new Binding("Brand")
            });
            Transport.Columns.Add(new DataGridTextColumn
            {
                Header = "Модель",
                Binding = new Binding("Model")
            });
        }

        private IEnumerable<Driver> GetDrivers(DateTime startDateTime, DateTime endDateTime)
        {
            

            DateOnly startDate = new DateOnly(startDateTime.Year, startDateTime.Month, startDateTime.Day);
            DateOnly endDate = new DateOnly(endDateTime.Year, endDateTime.Month, endDateTime.Day);

            var queryResult = from driver in App.context.Drivers.Local
                              where !(from waybill in App.context.Waybills
                                      where waybill.DepartureDate >= startDate && waybill.ArrivalDate <= endDate
                                      select waybill.DriverNumber)
                                      .Contains(driver.DriverId)
                              select driver;

            return queryResult;
        }



        private IEnumerable<Transport> GetTransport(DateTime startDateTime, DateTime endDateTime)
        {
            DateOnly startDate = new DateOnly(startDateTime.Year, startDateTime.Month, startDateTime.Day);
            DateOnly endDate = new DateOnly(endDateTime.Year, endDateTime.Month, endDateTime.Day);
            var queryResult = from transport in App.context.Transports.Local
                              where !(from waybill in App.context.Waybills
                                      where waybill.DepartureDate >= startDate && waybill.ArrivalDate <= endDate
                                      select waybill.TransportNumber)
                                      .Contains(transport.TransportId)
                              select transport;

            return queryResult;
        }

        private void Drivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Drivers.SelectedItem != null && waybill != null)
            {
                Model.Driver selectedDriver = (Model.Driver)Drivers.SelectedItem;
                waybill.DriverNumber = selectedDriver.DriverId;

                App.context.SaveChanges();
                MessageBox.Show("Водитель выбран!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                if (waybill.TransportNumber != null)
                {
                    OpenNewPage();
                }
            }
        }

        private void Transport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Transport.SelectedItem != null && waybill != null)
            {
                Model.Transport selectedTransport = (Model.Transport)Transport.SelectedItem;
                waybill.TransportNumber = selectedTransport.TransportId;

                App.context.SaveChanges();
                MessageBox.Show("Транспорт выбран!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                if (waybill.DriverNumber != null)
                {
                    OpenNewPage();
                }
            }
        }

        private void OpenNewPage()
        {
            Pages.FullWaybill full = new Pages.FullWaybill();
            Classes.Navigate.Card.Navigate(full);
        }

        private void StartWayb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

        private void StartWayb_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private void EndWayb_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private void EndWayb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }
    }
}
