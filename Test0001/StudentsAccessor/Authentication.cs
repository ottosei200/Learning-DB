using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAccessor {
    public class Authentication {
        public static string ConsoleInputPassword() {
            string password = "";

            // マスキング入力
            while (true) {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter) {
                    Console.WriteLine();
                    break;
                } else if (key.Key == ConsoleKey.Backspace && password.Length > 0) {
                    password = password.Substring(0, password.Length - 1);

                    Console.Write("\b \b");
                } else if (!char.IsControl(key.KeyChar)) {
                    password += key.KeyChar;
                    Console.Write('*');
                }
            }

            return password;
        }
    }
}
