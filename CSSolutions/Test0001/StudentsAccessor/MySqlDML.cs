using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace StudentsAccessor {
    public class MySqlDML : IManipulation {
        private string ConnectionString { get; init; }
        private string Table { get; init; } // どのテーブルから値をとってくるか

        public MySqlDML(string connectionString, string table) {
            ConnectionString = connectionString;
            Table = table;
        }

        public MySqlDataReader Select(params string[] columns) {
            // SQL文を組み立てる
            StringBuilder query = new StringBuilder();
            query.Append("select ");

            // 列名
            int length = columns.Length;
            for (int i = 1; i <= length; i++) {
                if (i == length) { // 最後
                    query.Append(columns[i - 1]);
                } else {
                    query.Append(columns[i - 1]);
                    query.Append(',');
                }
            }
            query.Append(' ');
            query.Append("from ");
            query.Append(Table);
            query.Append(';');

            Console.WriteLine(query.ToString());

            using var connection = new MySqlConnection();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = query.ToString();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine(reader.GetName(0));
            while (reader.Read()) {
                Console.WriteLine(reader.GetValue(0));

            }

            return command.ExecuteReader();
        }

        public void Insert() {
            throw new NotImplementedException();
        }

        public void Update() {
            throw new NotImplementedException();
        }

        public void Delete() {
            throw new NotImplementedException();
        }
    }
}
