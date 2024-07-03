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

namespace EconSense.Pages.Actions
{
    /// <summary>
    /// Логика взаимодействия для EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Page
    {
        public EditStaff()
        {
            InitializeComponent();
            LoadData();


        }
        public void LoadData()
        {
            StaffView.Children.Clear();
            List<Model.User> list = App.context.Users.ToList();
            foreach (var item in list)
            {
                if (item.UserId == Classes.ID.idStaff)
                {
                    StaffView.Children.Add(new Cards.EditStaff(item.UserId, item.FirstName, item.LastName, item.Patronymic, item.Email, item.PassportSeriesAndNumber, item.PhoneNumber, item.ActualResidentialAddress, item.PlaceOfResidence, item.Position, DateTime.Parse(item.DateOfBirth.ToString())));
                    break; 
                }
            }

        }
    }
}
