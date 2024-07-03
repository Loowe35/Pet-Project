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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для Expenses.xaml
    /// </summary>
    public partial class Expenses : Page
    {
        public Expenses()
        {
            InitializeComponent();
            LoadFull();
        }
        public void LoadFull()
        {
            var waybill = (from w in App.context.Waybills
                           join d in App.context.Drivers on w.DriverNumber equals d.DriverId
                           join t in App.context.Transports on w.TransportNumber equals t.TransportId
                           join c in App.context.Cargoes on w.CargoNumber equals c.CargoId
                           join r in App.context.Routes on w.RouteNumber equals r.RouteId
                           where w.WaybillId == Classes.ID.idWaybInfo
                           select new
                           {
                               DriverName = $"{d.LastName} {d.FirstName} {d.Patronymic}",
                               Transport = $"{t.Brand} {t.Model}",
                               Cargo = c.CargoName,
                               RouteLength = r.RouteLength,
                               EndingPoint = r.EndingPoint,
                               Route = r.RouteName
                           }).FirstOrDefault();

            if (waybill != null)
            {
                Fio.Content = waybill.DriverName;
                Transport.Content = waybill.Transport;
                Cargo.Content = waybill.Cargo;
                Lenth.Content = waybill.RouteLength;
                DotEnd.Content = waybill.EndingPoint;
                Route.Content = waybill.Route;
            }
        }


        private decimal GetRouteLength()
        {
            var waybillInfo = (from w in App.context.Waybills
                               join r in App.context.Routes on w.RouteNumber equals r.RouteId
                               where w.WaybillId == Classes.ID.idWaybInfo
                               select r.RouteLength).FirstOrDefault();

            return waybillInfo ?? 0m; // Возвращаем длину маршрута, если она найдена, иначе 0
        }


        private decimal? CalculateFuelUsed(double routeLength)
        {
            var waybillInfo = (from w in App.context.Waybills
                               join t in App.context.Transports on w.TransportNumber equals t.TransportId
                               where w.WaybillId == Classes.ID.idWaybInfo
                               select new
                               {
                                   AverageFuelConsumption = t.AverageFuelConsumption
                               }).FirstOrDefault();

            if (waybillInfo != null)
            {
                decimal averageFuelConsumption = waybillInfo.AverageFuelConsumption ?? 0m; // Средний расход топлива на 100 км (в литрах)

                // Рассчитываем количество затраченного топлива
                decimal fuelUsed = (decimal)(routeLength / 100) * averageFuelConsumption; // В литрах

                return fuelUsed;
            }
            else
            {
                return null; // Возвращаем null, если информация о путевом листе или транспорте не найдена
            }
        }
        private const decimal FuelPricePerLiter = 53m;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var waybill = App.context.Waybills.FirstOrDefault(w => w.WaybillId == Classes.ID.idWaybInfo);
            if (waybill != null)
            {
                waybill.Status = "Обновленный статус"; // Замените "Обновленный статус" на ваше актуальное значение
            }

            // Сохраняем изменения в базе данных
            App.context.SaveChanges();

            // Получаем значения из текстовых полей
            decimal repairCost = decimal.Parse(Repair.Text);
            decimal downtimeHours = decimal.Parse(Downtime.Text);
            decimal lossesDueToDowntime = decimal.Parse(Losses.Text);

            // Получаем длину маршрута
            double routeLength = (double)GetRouteLength();

            // Вычисляем количество потраченного топлива
            decimal? fuelUsed = CalculateFuelUsed(routeLength);
            decimal fuelCost = (fuelUsed ?? 0m) * FuelPricePerLiter;

            // Суммируем все расходы
            decimal totalExpenses = fuelCost + repairCost + lossesDueToDowntime + downtimeHours;
           

            // Создаем новый объект TransportExpense
            TransportExpense expense = new TransportExpense
            {
                WaybillId = Classes.ID.idWaybInfo, // Используйте нужное значение идентификатора путевого листа
                Fuel = fuelUsed,
                MaintenanceAndRepair = repairCost,
                ForcedDowntime = downtimeHours,
                LossesDueToDowntime = lossesDueToDowntime
            };

            // Добавляем объект в контекст базы данных
            App.context.TransportExpenses.Add(expense);

            // Сохраняем изменения в базе данных
            App.context.SaveChanges();

            // Экспортируем данные в Excel с общими расходами
            ExportToExcel(new List<TransportExpense> { expense }, totalExpenses);

            // Отображаем сообщение об успешном добавлении
            MessageBox.Show("Расходы успешно добавлены в базу данных.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExportToExcel(IEnumerable<TransportExpense> expenses, decimal totalExpenses)
        {
            string fileName = $"Expenses_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            string filePath = System.IO.Path.Combine(@"C:\Users\shaki\Desktop\Excel\", fileName);

            // Устанавливаем контекст лицензии перед созданием объекта ExcelPackage
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Создаем новый файл Excel
            FileInfo newFile = new FileInfo(filePath);
            using (ExcelPackage excelPackage = new ExcelPackage(newFile))
            {
                var currentUserId = Classes.ID.IDUser; // Предположим, что здесь содержится идентификатор текущего пользователя
                var currentUserFullName = (from u in App.context.Users // Замените "Users" на ваше название таблицы с пользователями
                                           where u.UserId == currentUserId
                                           select $"{u.LastName} {u.FirstName} {u.Patronymic}").FirstOrDefault();
                // Получаем данные из запроса
                var waybillData = (from w in App.context.Waybills
                                   join d in App.context.Drivers on w.DriverNumber equals d.DriverId
                                   join t in App.context.Transports on w.TransportNumber equals t.TransportId
                                   join c in App.context.Cargoes on w.CargoNumber equals c.CargoId
                                   join r in App.context.Routes on w.RouteNumber equals r.RouteId
                                   join u in App.context.Users on w.DriverNumber equals u.UserId // Предположим, что таблица Users содержит информацию о сотрудниках
                                   where w.WaybillId == Classes.ID.idWaybInfo
                                   select new
                                   {
                                       DriverName = $"{d.LastName} {d.FirstName} {d.Patronymic}",
                                       Transport = $"{t.Brand} {t.Model}",
                                       Cargo = c.CargoName,
                                       RouteLength = r.RouteLength,
                                       EndingPoint = r.EndingPoint,
                                       Route = r.RouteName,
                                       CurrentUserFullName = currentUserFullName
                                   }).FirstOrDefault();


                if (waybillData != null)
                {
                    var Excel = new Microsoft.Office.Interop.Excel.Application();
                    var xlWB = Excel.Workbooks.Open(@"C:\Users\shaki\Desktop\Лист Microsoft Excel.xlsx");
                    var xlSht = xlWB.Worksheets[1];
                    xlSht.Cells[12, 3] = waybillData.DriverName;
                    xlSht.Cells[10, 3] = waybillData.Route;
                    xlSht.Cells[8, 7] = Classes.ID.idWaybInfo;
                    double routeLength = (double)waybillData.RouteLength;

                    // Вычисляем количество потраченного топлива
                    decimal? fuelUsed = CalculateFuelUsed(routeLength);

                    // Выводим количество потраченного топлива
                    if (fuelUsed.HasValue)
                    {
                        xlSht.Cells[19, 3].Value = fuelUsed.Value;
                    }
                    xlSht.Cells[14, 3] = waybillData.Transport;
                    xlSht.Cells[19, 5].Value = Repair.Text;
                    xlSht.Cells[19, 7].Value = Losses.Text;
                    xlSht.Cells[22, 8].Value = Downtime.Text;
                    xlSht.Cells[26, 3] = waybillData.Cargo;
                    xlSht.Cells[26, 4] = waybillData.RouteLength;
                    xlSht.Cells[26, 6] = waybillData.EndingPoint;
                    xlSht.Cells[40, 4] = waybillData.CurrentUserFullName;
                    xlSht.Cells[31, 8] = totalExpenses;
                    Excel.Visible = true;
                }
            }
        }

    }
}
