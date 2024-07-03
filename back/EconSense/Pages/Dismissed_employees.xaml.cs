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
    /// Логика взаимодействия для Dismissed_employees.xaml
    /// </summary>
    public partial class Dismissed_employees : Page
    {
        public Dismissed_employees()
        {
            InitializeComponent();
            LoadData();


        }
        public void LoadData()
        {
            StaffView.Children.Clear();
            List<Model.User> list = App.context.Users.ToList();
            int totalCount = list.Count(u => u.Status == "Уволен");
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
            int filteredCount = list.Count(u => u.Status == "Уволен");
            foreach (var item in list)
            {
                // Проверяем статус сотрудника
                if (item.Status == "Уволен")
                {
                    var staffers = new Cards.Dismissed(item.UserId, item.FirstName, item.LastName, item.Patronymic, item.Email, item.PassportSeriesAndNumber, item.PhoneNumber, item.ActualResidentialAddress, item.PlaceOfResidence, item.Position, item.Status, Convert.ToString(item.DateOfBirth));


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
            Pages.Staff staff = new Pages.Staff();
            Classes.Navigate.Card.Navigate(staff);
        }
    }
}
