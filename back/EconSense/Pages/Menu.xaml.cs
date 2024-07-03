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
using EconSense.Classes;
using EconSense.Model;

namespace EconSense.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            User user = App.context.Users.ToList().Find(u => u.UserId == ID.IDUser);
            dol.Content = user.Position;
            
            name.Content = user.FirstName + " " + user.Patronymic;
        }
    }
}
