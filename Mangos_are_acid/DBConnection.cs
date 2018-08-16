using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace Data
{
    public class DBConnection
    {
        private DBConnection() { }

        // Private data for connection
        private string databaseName = "mangos";
        private string serverName   = "127.0.0.1";
        private string port         = "3306";
        private string user         = string.Empty;
        private string pass         = string.Empty;

        public string PortNumber
        {
            get { return port; }
            set { port = value; }
        }

        public string Password
        {
            get { return pass; }
            set { pass = value; }
        }

        public string Username
        {
            get { return user; }
            set { user = value; }
        }

        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=" + serverName + ";Database=mangos;User id=" + Username + ";Password=" + Password + ";persistsecurityinfo=True;port=" + PortNumber + ";SslMode=none;", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }
            return true;
        }

        public void Close() { connection.Close(); }
    }
}