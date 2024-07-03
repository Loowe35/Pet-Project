using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconSense.Classes
{
    internal class BD
    {
        public static MySqlConnection connection = new MySqlConnection(@"Server=127.0.0.1;Port=3307;User=root;Password=;Database=Econom");
        public void openConnetion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public void closeConnetion()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetMySqlConnection()
        {
            return connection;
        }
    }
}
