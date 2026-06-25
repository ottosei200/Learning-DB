using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace ManagerCustomers.DAO {
    public class Connector {
        private static string connectionString = "Server = 127.0.0.1; Port = 3306; User ID = dev_user; Password = dev_password; Database = my_database; AllowPublicKeyRetrieval = true; SslMode = None";
        public static MySqlConnection connection;

        public Connector() {
            Connector.connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
        }
    }
}
