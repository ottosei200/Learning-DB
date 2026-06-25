using ManagerCustomers.DAO;
using ManagerCustomers.DAO.Delete;
using ManagerCustomers.DAO.Insert;
using ManagerCustomers.DAO.Search;
using ManagerCustomers.DAO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomers {
    public class Core {
        public static void Run() {
            Console.WriteLine("【顧客情報管理システム】");

            while (true) {
                Console.WriteLine("【メニュー】終了:q, 検索・表示:1, 追加:2");
                Utils.ConsoleInputString(out string input);

                DAOCommands command = (input) switch {
                    "1" => DAOCommands.Search,
                    "2" => DAOCommands.Insert,
                    "q" => DAOCommands.Exit,
                    _ => DAOCommands.None,
                };

                if (command == DAOCommands.Exit) {
                    break;
                }

                if (command == DAOCommands.None) {
                    Console.WriteLine("入力が無効です");
                    Console.WriteLine();
                    continue;
                }

                Action action = (command) switch {
                    DAOCommands.Search => SearchProcessor.Run,
                    DAOCommands.Insert => InsertProcessor.Run,
                    DAOCommands.Update => UpdateProcessor.Run,
                    DAOCommands.Delete => DeleteProcessor.Run,
                    _ => () => { }
                };

                Console.WriteLine();
                action();
                Console.WriteLine();
            }

            Console.WriteLine("終了しました");
        }
    }
}
