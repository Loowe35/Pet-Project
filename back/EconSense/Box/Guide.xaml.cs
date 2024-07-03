using EconSense.Classes;
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
using System.Windows.Shapes;
using EconSense.Model;
using EconSense.Pages;
using EconSense.Cards;

namespace EconSense.Box
{
    /// <summary>
    /// Логика взаимодействия для Guide.xaml
    /// </summary>
    public partial class Guide : Window
    {
        public Guide()
        {
            InitializeComponent();
            Fraim_Main.Content = new EconSense.Pages.Menu();
            Classes.Navigate.Win = this;
            Fraim_Main.Navigate(new Pages.Menu());
            Classes.Navigate.Card = this.Fraim_Main;
            Date.Content = DateTime.Now.ToLongDateString(); Time.Content = DateTime.Now.ToLongTimeString();
            var timer = new System.Windows.Threading.DispatcherTimer(); timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true; timer.Tick += (o, e) => { Time.Content = DateTime.Now.ToLongTimeString().ToString(); };
            timer.Start();
            User user = App.context.Users.ToList().Find(u => u.UserId == ID.IDUser);
            name.Content = user.FirstName;
        }


        private void Minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fraim_Main.Navigate(new Pages.Staff());
            titl.Content = "Сотрудники";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fraim_Main.Navigate(new Pages.Menu());
            titl.Content = "Главное меню";
        }

        private void drivers_Click(object sender, RoutedEventArgs e)
        {
            Fraim_Main.Navigate(new Pages.Drivers());
            titl.Content = "Водители";
        }

        private void Trans_Click(object sender, RoutedEventArgs e)
        {
            Fraim_Main.Navigate(new Pages.transport_vehicle());
            titl.Content = "Транспорт";
        }

        private void Waybill_Click(object sender, RoutedEventArgs e)
        {
            Fraim_Main.Navigate(new Pages.Cargos());
            titl.Content = "Путевой лист";
            Classes.ID.idRoute = 0;
        }
    }
}
