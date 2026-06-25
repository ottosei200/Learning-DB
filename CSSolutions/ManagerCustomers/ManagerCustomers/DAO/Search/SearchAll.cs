//#define INDEV 

using ManagerCustomers.DAO.Entity;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomers.DAO.Search {
    internal class SearchAll : Connector, ISearch {
        public List<Customer> ExecuteSearch() {
            List<Customer> customers = new List<Customer>();

            // SQL文を組み立てる
            StringBuilder query = new StringBuilder();
            query.Append("select * from customers; ");
            query.Append("");

            //Console.WriteLine(query.ToString());

            MySqlCommand command = new MySqlCommand();
            command.CommandText = query.ToString();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            //Console.WriteLine(reader.GetName(0));
            while (reader.Read()) {
                for (int i = 0; i < reader.FieldCount; i++) {
                    Console.Write($"{reader.GetValue(i)} ");
                }
                Console.WriteLine();
            }

            connection.Close();

            return customers;
        }
    }
}
