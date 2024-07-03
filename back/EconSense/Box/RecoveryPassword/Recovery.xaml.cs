using Microsoft.EntityFrameworkCore;
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

namespace EconSense.Box
{
    /// <summary>
    /// Логика взаимодействия для Recovery.xaml
    /// </summary>
    public partial class Recovery : Window
    {
        public Recovery()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var user = App.context.Users.FirstOrDefault(u => u.Login == LoginBox.Text && u.Status == "Работает");
            if (user != null)
            {
                Classes.ID.IDRecovery = user.UserId;
                Box.RecoveryPassword.RecoveryEmail recoveryEmail = new Box.RecoveryPassword.RecoveryEmail();
                recoveryEmail.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином не найден или не работает.");
            }
        }
        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
