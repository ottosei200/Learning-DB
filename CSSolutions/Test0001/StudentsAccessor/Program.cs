using MySqlConnector;

namespace StudentsAccessor {
    internal class Program {
        static void Main(string[] args) {
            // ログイン
            Console.Write("Enter the password: ");
            string password = Authentication.ConsoleInputPassword();
            Console.WriteLine("Logging in ...");

            // ロックされたときは'sudo mysqladmin flush-hosts'でログイン可能に戻す
            string connectionString = $"Server=localhost;Database=practice0001;Uid=vscode_user;Pwd={password}";

            // 接続の確認
            using (var connection = new MySqlConnection(connectionString)) {
                try {
                    connection.Open();
                    Console.WriteLine("MySQLサーバーに接続しました。");

                    string sql = "select version(); ";
                    using (var command = new MySqlCommand(sql, connection)) {
                        var version = command.ExecuteScalar();
                        Console.WriteLine($"MySQLのバージョン: {version}");
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                } finally {
                    connection.Close();
                }
            }

            try {
                MySqlDML dml = new MySqlDML(connectionString, "students");

                Console.WriteLine(dml.Select("*"));
            } catch (MySqlException ex) {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
