using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
    /// Логика взаимодействия для ViewWaybills.xaml
    /// </summary>
    public partial class ViewWaybills : Page
    {
        public ViewWaybills()
        {
            InitializeComponent();
            Loaded += ViewWaybills_Loaded;
            Unloaded += ViewWaybills_Unloaded; // Подписываемся на событие выгрузки страницы
        }

        private void ViewWaybills_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ViewWayb.Items.Clear();
            var queryResult = (from w in App.context.Waybills
                               join d in App.context.Drivers on w.DriverNumber equals d.DriverId
                               join t in App.context.Transports on w.TransportNumber equals t.TransportId
                               join r in App.context.Routes on w.RouteNumber equals r.RouteId
                               where w.Status == "Выполнен"
                               select new
                               {
                                   WaybillId = w.WaybillId, // Добавляем WaybillId в результат запроса
                                   DriverName = $"{d.LastName} {d.FirstName} {d.Patronymic}",
                                   Transport = $"{t.Brand} {t.Model}",
                                   RouteName = r.RouteName,
                                   DepartureTime = w.DepartureDate != null ? w.DepartureDate.Value.ToShortDateString() : null,
                                   ArrivalTime = w.ArrivalDate != null ? w.ArrivalDate.Value.ToShortDateString() : null
                               }).ToList();

            foreach (var item in queryResult)
            {
                ViewWayb.Items.Add(item);
            }
        }

        private void ViewWaybills_Unloaded(object sender, RoutedEventArgs e)
        {
            // Присваиваем переменной null при выгрузке страницы
            ViewWayb.ItemsSource = null;
        }

        private void ViewWayb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewWayb.SelectedItem != null)
            {
                dynamic selectedItem = ViewWayb.SelectedItem; 
                                                              
                Classes.ID.idWaybInfo = selectedItem.WaybillId;

                Pages.Expenses ex = new Pages.Expenses();
                Classes.Navigate.Card.Navigate(ex);
            }
        }
    }

}

