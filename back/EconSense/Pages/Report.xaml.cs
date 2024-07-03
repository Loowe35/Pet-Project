using EconSense.Model;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public Report()
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
                               select new
                               {
                                   WaybillId = w.WaybillId, // Добавляем WaybillId в результат запроса
                                   DriverName = $"{d.LastName} {d.FirstName} {d.Patronymic}",
                                   Transport = $"{t.Brand} {t.Model}",
                                   RouteName = r.RouteName,
                                   DepartureTime = w.DepartureDate.HasValue ? w.DepartureDate.Value.ToShortDateString() : null,
                                   ArrivalTime = w.ArrivalDate.HasValue ? w.ArrivalDate.Value.ToShortDateString() : null
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

        private void ExportToExcel()
        {
            // Устанавливаем контекст лицензии перед созданием объекта ExcelPackage
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            DateTime startDateTime = Start.SelectedDate ?? DateTime.MinValue;
            DateTime endDateTime = End.SelectedDate ?? DateTime.MaxValue;

            DateOnly startDate = new DateOnly(startDateTime.Year, startDateTime.Month, startDateTime.Day);
            DateOnly endDate = new DateOnly(endDateTime.Year, endDateTime.Month, endDateTime.Day);

            // Получаем данные из запроса
            var queryResult = (from w in App.context.Waybills
                               join d in App.context.Drivers on w.DriverNumber equals d.DriverId
                               join t in App.context.Transports on w.TransportNumber equals t.TransportId
                               join r in App.context.Routes on w.RouteNumber equals r.RouteId
                               join c in App.context.Cargoes on w.CargoNumber equals c.CargoId
                               join u in App.context.Users on w.UserNumber equals u.UserId
                               join te in App.context.TransportExpenses on w.WaybillId equals te.WaybillId
                               where w.DepartureDate >= startDate && w.ArrivalDate <= endDate
                               select new
                               {
                                   WaybillNumber = w.WaybillId,
                                   DriverFullName = $"{d.LastName} {d.FirstName} {d.Patronymic}",
                                   Transport = $"{t.Brand} {t.Model}",
                                   RouteName = r.RouteName,
                                   StartingPoint = r.StartingPoint,
                                   EndingPoint = r.EndingPoint,
                                   RouteLength = r.RouteLength ?? 0, // Добавлено значение по умолчанию
                                   CargoName = c.CargoName,
                                   UserName = $"{u.LastName} {u.FirstName} {u.Patronymic}",
                                   DepartureDate = w.DepartureDate,
                                   ArrivalDate = w.ArrivalDate,
                                   MaintenanceAndRepair = te.MaintenanceAndRepair ?? 0, // Добавлено значение по умолчанию
                                   ForcedDowntime = te.ForcedDowntime ?? 0, // Добавлено значение по умолчанию
                                   LossesDueToDowntime = te.LossesDueToDowntime ?? 0, // Добавлено значение по умолчанию
                                   AverageFuelConsumption = t.AverageFuelConsumption ?? 0 // Добавлено значение по умолчанию
                               }).ToList();

            // Вычисление общей длины маршрутов, суммы всех расходов и расхода топлива
            decimal totalRouteLength = queryResult.Sum(x => x.RouteLength);
            decimal totalExpenses = queryResult.Sum(x => x.MaintenanceAndRepair + x.ForcedDowntime + x.LossesDueToDowntime);
            decimal totalFuelConsumption = queryResult.Sum(x => x.RouteLength * x.AverageFuelConsumption);

            // Цена топлива за литр
            decimal fuelPricePerLiter = 53m;
            decimal totalFuelCost = totalFuelConsumption * fuelPricePerLiter;

            if (queryResult != null && queryResult.Count > 0)
            {
                var Excel = new Microsoft.Office.Interop.Excel.Application();
                var xlWB = Excel.Workbooks.Open(@"C:\Users\shaki\Desktop\отчет.xlsx");
                var xlSht = xlWB.Worksheets[1];

                // Записываем общие значения длины маршрутов, суммы расходов и стоимости топлива в ячейки
                
                xlSht.Cells[12, 4].Value = totalRouteLength;
                xlSht.Cells[14, 2].Value = "Сумма всех расходов";
                xlSht.Cells[3, 3].Value = totalExpenses;
                xlSht.Cells[16, 2].Value = "Общий расход топлива (литры)";
                xlSht.Cells[4, 3].Value = totalFuelConsumption;
                xlSht.Cells[18, 2].Value = "Общая стоимость топлива (рубли)";
                xlSht.Cells[5, 3].Value = totalFuelCost;

                int row = 21;
                foreach (var expense in queryResult)
                {
                    // Записываем данные в ячейки
                    xlSht.Cells[row, 2].Value = expense.WaybillNumber;
                    xlSht.Cells[row, 3].Value = expense.DriverFullName;
                    xlSht.Cells[row, 5].Value = expense.Transport;
                    xlSht.Cells[row, 7].Value = expense.CargoName;
                    xlSht.Cells[row, 8].Value = expense.EndingPoint;

                    // Рисуем границы вокруг каждой ячейки
                    xlSht.Cells[row, 2].BorderAround();
                    xlSht.Cells[row, 3].BorderAround();
                    xlSht.Cells[row, 5].BorderAround();
                    xlSht.Cells[row, 7].BorderAround();
                    xlSht.Cells[row, 8].BorderAround();

                    row++;
                }
                Excel.Visible = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel();

            // Открываем созданный отчет
            string excelPath = @"C:\Program Files\Microsoft Office\root\Office16\excel.exe"; // Пример пути к excel.exe, укажите правильный путь
            string filePath = @"C:\Users\shaki\Desktop\отчет.xlsx"; // Путь к вашему файлу Excel
            Process.Start(excelPath, filePath);
        }
    }
}
