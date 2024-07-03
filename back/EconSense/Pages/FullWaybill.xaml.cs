using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;

namespace EconSense.Pages
{
    public partial class FullWaybill : Page
    {
        public FullWaybill()
        {
            InitializeComponent();
            LoadWaybillData();
            LoadRoadData();
        }

        private void LoadWaybillData()
        {
            var waybillData = (from w in App.context.Waybills
                               join d in App.context.Drivers on w.DriverNumber equals d.DriverId
                               join t in App.context.Transports on w.TransportNumber equals t.TransportId
                               join r in App.context.Routes on w.RouteNumber equals r.RouteId
                               join c in App.context.Cargoes on w.CargoNumber equals c.CargoId
                               join u in App.context.Users on w.UserNumber equals u.UserId
                               join rs in App.context.RouteSections on r.RouteId equals rs.RouteNumber into rsGroup
                               from rs in rsGroup.DefaultIfEmpty()
                               join rd in App.context.Roads on rs.RoadNumber equals rd.RoadId into rdGroup
                               from rd in rdGroup.DefaultIfEmpty()
                               where w.WaybillId == Classes.ID.idWayb
                               select new
                               {
                                   w.WaybillId,
                                   Driver_Name = d.LastName + " " + d.FirstName + " " + d.Patronymic,
                                   Transport = t.Brand + " " + t.Model,
                                   r.RouteName,
                                   c.CargoName,
                                   User_Name = u.LastName + " " + u.FirstName + " " + u.Patronymic,
                                   w.DepartureDate,
                                   w.ArrivalDate,
                                   Road_Name = rd != null ? rd.RoadName : null
                               }).FirstOrDefault();

            if (waybillData != null)
            {
                FIO.Content = waybillData.Driver_Name;
                BrandModel.Content = waybillData.Transport;
                Route.Content = waybillData.RouteName;
                Date.Content = waybillData.DepartureDate.ToString();
                Arrival.Content = waybillData.ArrivalDate.ToString();
            }
        }

        private void LoadRoadData()
        {
            var roadData = (from w in App.context.Waybills
                            join rs in App.context.RouteSections on w.RouteNumber equals rs.RouteNumber
                            join rd in App.context.Roads on rs.RoadNumber equals rd.RoadId
                            where w.WaybillId == Classes.ID.idWayb
                            select new
                            {
                                rd.RoadId,
                                rd.RoadName
                            }).ToList();

            RoadAll.ItemsSource = roadData;

            // Удаляем все столбцы перед добавлением новых, чтобы избежать дублирования
            RoadAll.Columns.Clear();

            // Добавляем столбцы снова
            RoadAll.Columns.Add(new DataGridTextColumn
            {
                Header = "Номер дороги",
                Binding = new Binding("RoadId")
            });
            RoadAll.Columns.Add(new DataGridTextColumn
            {
                Header = "Название дороги",
                Binding = new Binding("RoadName")
            });
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Pages.Cargos cargos = new Pages.Cargos();
            Classes.Navigate.Card.Navigate(cargos);
        }
    }
}
