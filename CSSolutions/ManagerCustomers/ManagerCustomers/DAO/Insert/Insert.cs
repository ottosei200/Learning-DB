using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ManagerCustomers.DAO.Insert {
    public class Insert : Connector, IInsert {
        public void ExecuteInsert() {
            StringBuilder query = new StringBuilder();
            query.Append("insert into customers(cust_id, cust_name, phone_num) ");
            query.Append("values(@CUST_ID, @CUST_NAME, @PHONE_NUM); ");

            Utils.ConsoleInputString("顧客ID: ", out string inputCustId);
            Utils.ConsoleInputString("顧客名: ", out string inputCustName);
            Utils.ConsoleInputString("電話番号: ", out string inputPhoneNum);

            MySqlParameter pCustId = new MySqlParameter("@CUST_ID", MySqlDbType.Int32);
            pCustId.Value = inputCustId;
            pCustId.Direction = System.Data.ParameterDirection.Input;

            MySqlParameter pCustName = new MySqlParameter("@CUST_NAME", MySqlDbType.String);
            pCustName.Value = inputCustName;
            pCustName.Direction = System.Data.ParameterDirection.Input;

            MySqlParameter pPhoneNum = new MySqlParameter("@PHONE_NUM", MySqlDbType.String);
            pPhoneNum.Value = inputPhoneNum;
            pPhoneNum.Direction = System.Data.ParameterDirection.Input;

            MySqlCommand command = new MySqlCommand();
            command.CommandText = query.ToString();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.Parameters.Add(pCustId);
            command.Parameters.Add(pCustName);
            command.Parameters.Add(pPhoneNum);

            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;

            using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required, options)) {
                connection.Open();

                int count = command.ExecuteNonQuery();

                if (count == 0) {
                    Console.WriteLine($"処理されませんでした");
                    return;
                }

                while (true) {
                    // 確定するかどうか
                    Utils.ConsoleInputString("確定しますか?(y/n): ", out string input);
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

                    tx.Complete();
                    Console.WriteLine("データが挿入されました");
                    break;
                }
            }
        }
    }
}
