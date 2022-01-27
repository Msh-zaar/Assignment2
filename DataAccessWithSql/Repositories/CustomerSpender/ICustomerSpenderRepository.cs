using DataAccessWithSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public interface ICustomerSpenderRepository
    {
        /// <summary>
        /// Retrieves a list of CustomerSpender objects which contain 
        /// the first and last names of the customer as well as their total
        /// </summary>
        /// <returns>A List of CustomerSpender objects</returns>
        public List<CustomerSpender> GetHighSpenders();
    }
}
