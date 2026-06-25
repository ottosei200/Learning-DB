using ManagerCustomers.DAO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomers.DAO.Search {
    public interface ISearch {
        public List<Customer> ExecuteSearch();
    }
}
