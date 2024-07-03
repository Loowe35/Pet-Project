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
using EconSense.Classes;

namespace EconSense.Box
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            
        }
       

        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length != 0 && PasswordBoxHide.Password.Length != 0)
            {
                // Находим активного сотрудника с указанным логином
                User user = App.context.Users.FirstOrDefault(u => u.Login == LoginBox.Text && u.Status == "Работает");

                // Если пользователь существует и его пароль совпадает
                if (user != null && user.Password == PasswordBoxHide.Password)
                {
                    if (user.Position == "Логист")
                    {
                        ID.IDUser = user.UserId;
                        MessageBox.Show($"Добро пожаловать, {user.FirstName} {user.Patronymic}!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Guide guide = new Guide();
                        guide.Show();
                        this.Close();
                        return;
                    }
                    if (user.Position == "Экономист")
                    {
                        ID.IDUser = user.UserId;
                        MessageBox.Show($"Добро пожаловать, {user.FirstName} {user.Patronymic}!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Economist eco = new Economist();
                        eco.Show();
                        this.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели неверные данные!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Box.Recovery recovery = new Box.Recovery();
            recovery.Show();
        }
    }
}
