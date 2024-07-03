using EconSense.Model;
using System.Configuration;
using System.Data;
using System.Windows;

namespace EconSense
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EconomContext context { get; } = new EconomContext();
    }

}
