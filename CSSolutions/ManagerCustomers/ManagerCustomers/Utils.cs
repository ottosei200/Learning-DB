using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomers {
    public class Utils {
        public static void ConsoleInputString(out string value) {
            while (true) {
                Console.Write("操作を入力: ");
                value = Console.ReadLine()!;

                if (string.IsNullOrEmpty(value)) {
                    continue;
                }

                break;
            }
        }
        public static void ConsoleInputString(string text, out string value) {
            while (true) {
                Console.Write(text);
                value = Console.ReadLine()!;

                if (string.IsNullOrEmpty(value)) {
                    continue;
                }

                break;
            }
        }

    }
}
