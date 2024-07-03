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

namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для Staff.xaml
    /// </summary>
    public partial class Staff : Page
    {
        public Staff()
        {
            InitializeComponent();
            LoadData();

            
        }
        public void LoadData()
        {
            StaffView.Children.Clear();
            List<Model.User> list = App.context.Users.ToList();
            int totalCount = list.Count(u => u.Status == "Работает");
            if (Filtration.SelectedItem != null)
            {
                switch (Filtration.SelectedIndex)
                {
                    case 0:
                        list = App.context.Users.Where(u => u.Position == "Логист").ToList();
                        break;
                    case 1:
                        list = App.context.Users.Where(u => u.Position == "Экономист").ToList();
                        break;
                }
            }
            if (Search.Text.Length != 0)
            {
                string searchText = Search.Text.ToLower(); 
                list = list.Where(u =>
                    u.FirstName.ToLower().Contains(searchText) || 
                    u.LastName.ToLower().Contains(searchText) || 
                    u.Patronymic.ToLower().Contains(searchText) 
                ).ToList();
            }

            int filteredCount = list.Count(u => u.Status == "Работает");
            foreach (var item in list)
            {
                // Проверяем статус сотрудника
                if (item.Status == "Работает")
                {
                    var staffers = new Cards.Staffers(item.UserId, item.FirstName, item.LastName, item.Patronymic, item.Email, item.PassportSeriesAndNumber, item.PhoneNumber, item.ActualResidentialAddress, item.PlaceOfResidence, item.Position, Convert.ToString(item.DateOfBirth));

                    staffers.StatusChanged += (sender, e) =>
                    {
                        LoadData();
                    };
                    StaffView.Children.Add(staffers);
                }
            }
            RecordsCountLabel.Content = $"Сотрудники: {filteredCount}/{totalCount}";
           
        }

        private void Filtration_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = string.Empty;
            Filtration.SelectedIndex = -1;
            LoadData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pages.Actions.AddStaff add = new Pages.Actions.AddStaff();
            Classes.Navigate.Card.Navigate(add);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Pages.Dismissed_employees diss = new Pages.Dismissed_employees();
            Classes.Navigate.Card.Navigate(diss);
        }
    }
}
