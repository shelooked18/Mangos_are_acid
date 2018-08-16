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
using Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Mangos_are_acid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var dbCon = DBConnection.Instance();
            dbCon.ServerName = "127.0.0.1";
            dbCon.Username = "root";
            dbCon.Password = "1234";

            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM creature_template WHERE Entry=16980";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var data = reader.GetValue(i);
                        if (data != null)
                            Console.WriteLine(data);
                    }
                }
                dbCon.Close();
            }
        }
    }
}
