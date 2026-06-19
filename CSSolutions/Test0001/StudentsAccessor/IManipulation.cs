using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace StudentsAccessor {
    internal interface IManipulation {
        public MySqlDataReader Select(params string[] columns);
        public void Insert();
        public void Update();
        public void Delete();
    }
}
