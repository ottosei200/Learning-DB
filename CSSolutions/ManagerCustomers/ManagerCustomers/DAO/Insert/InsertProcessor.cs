using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomers.DAO.Insert {
    public class InsertProcessor {
        public static void Run() {
            while (true) {
                Utils.ConsoleInputString("【メニュー＞追加】顧客情報を追加しますか?(y/n): ", out string input);

                YesNoCommands c = input switch {
                    var s when s.ToLower().StartsWith("y") => YesNoCommands.Yes,
                    var s when s.ToLower().StartsWith("n") => YesNoCommands.No,
                    _ => YesNoCommands.NotAnswer,
                };

                if (c == YesNoCommands.No) {
                    return;
                }

                if (c == YesNoCommands.NotAnswer) {
                    continue;
                }

                IInsert insert = new Insert();
                insert.ExecuteInsert();

                Console.WriteLine();
            }
        }
    }
}
