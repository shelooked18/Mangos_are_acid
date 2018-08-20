using System.Windows;
using Data;

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
            if (Properties.Settings.Default.RememberMe == true)
            {
                RememberMe.IsChecked = true;
                Server.Text = Properties.Settings.Default.Server;
                Port.Text = Properties.Settings.Default.Port;
                Username.Text = Properties.Settings.Default.Username;
                Password.Password = Properties.Settings.Default.Password;
            }
            else
            {
                Server.Text = Properties.Settings.Default.DefaultServer;
                Port.Text = Properties.Settings.Default.DefaultPort;
                Username.Text = Properties.Settings.Default.DefaultUsername;
            }
            
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.ServerName            = Server.Text;
            dbCon.PortNumber            = Port.Text;
            dbCon.Username              = Username.Text;
            dbCon.Password              = Password.Password;
            bool remember_credentials   = (bool) RememberMe.IsChecked;

            if (remember_credentials)
            {
                Properties.Settings.Default.Server      = Server.Text;
                Properties.Settings.Default.Port        = Port.Text;
                Properties.Settings.Default.Username    = Username.Text;
                Properties.Settings.Default.Password    = Password.Password;
                Properties.Settings.Default.RememberMe  = remember_credentials;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }
                
            dbCon.Connect();

            //if (dbCon.Connection != null)
            //{
            //    string query = "SELECT * FROM creature_template WHERE Entry=16980";
            //    var cmd = new MySqlCommand(query, dbCon.Connection);
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        for (int i = 0; i < reader.FieldCount; i++)
            //        {
            //            var data = reader.GetValue(i);
            //            if (data != null)
            //                Console.WriteLine(data);
            //        }
            //    }
            //}

            dbCon.Close();
        }
    }
}
