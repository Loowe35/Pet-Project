using EconSense.Classes;
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

namespace EconSense.Cards
{
    /// <summary>
    /// Логика взаимодействия для Staffers.xaml
    /// </summary>
    public partial class Staffers : UserControl
    {

        int id;
        public Frame FrameMain { get; set; }

        public Staffers( int id,string Name, string Fam, string Patr, string mail, string pasport, string phone, string place, string placeNow, string pos, string birth)
        {

            InitializeComponent();
            
            this.id = id;
            this.FIO.Content = Fam + " " + Name + " " + Patr;
            this.birht.Content = birth;
            this.Pasport.Content = pasport;
            this.phone.Content = phone;
            this.Mail.Content = mail;
            this.place.Content = place;
            this.Fact_place.Content = placeNow;
            this.position.Content = pos;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.ID.idStaff = id;
            Pages.Actions.EditStaff edit = new Pages.Actions.EditStaff();
            Classes.Navigate.Card.Navigate(edit);
        }
        public event EventHandler StatusChanged;

        // Метод, который вызывается при изменении статуса
        private void OnStatusChanged()
        {
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var user = App.context.Users.FirstOrDefault(u => u.UserId == id);
            if (user.UserId == Classes.ID.IDUser) 
            {
                MessageBox.Show("Вы не можете уволить себя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            var result = MessageBox.Show($"Вы уверены, что хотите уволить {user.LastName} {user.FirstName}?", "Уведомление!", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (user != null)
                {
                    user.Status = "Уволен";

                    try
                    {

                        App.context.SaveChanges();
                        MessageBox.Show($"Сотрудник {user.LastName} {user.FirstName} Уволен!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                        OnStatusChanged();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при изменении статуса сотрудника: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Сотрудник не найден.");
                }
            }
        }
    }
}
