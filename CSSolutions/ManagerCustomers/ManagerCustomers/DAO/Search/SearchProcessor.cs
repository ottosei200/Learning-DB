using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomers.DAO.Search {
    public static class SearchProcessor {
        const string connectionString = "a";
        public static void Run() {
            while (true) {
                Console.WriteLine("【メニュー＞検索・表示】キャンセル:q, 全件表示:1");
                Utils.ConsoleInputString(out string input);

                SearchCommands command = (input) switch {
                    "1" => SearchCommands.All,
                    "q" => SearchCommands.Exit,
                    _ => SearchCommands.None,
                };

                if (command == SearchCommands.Exit) {
                    return;
                }

                if (command == SearchCommands.None) {
                    Console.WriteLine("入力が無効です");
                    Console.WriteLine();
                    continue;
                }

                ISearch search = GetSearchCategory(command);

                search.ExecuteSearch();

                return;
            }
        }

        private static ISearch GetSearchCategory(SearchCommands command) {
            ISearch search;
            switch (command) {
                case SearchCommands.All: {
                        search = new SearchAll();
                        break;
                    }
                default:
                    throw new InvalidOperationException();
            }
            return search;
        }
    }
}
