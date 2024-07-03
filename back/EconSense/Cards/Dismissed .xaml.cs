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
    /// Логика взаимодействия для Dismissed.xaml
    /// </summary>
    public partial class Dismissed : UserControl
    {
        int id;
        public Frame FrameMain { get; set; }
        public Dismissed(int id, string Name, string Fam, string Patr, string mail, string pasport, string phone, string place, string placeNow, string pos, string status, string birth)
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
            this.stat.Content = status;
        }
    }
}
