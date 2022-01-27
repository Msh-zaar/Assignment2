using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Models
{
    public class CustomerSpender
    {
        /// <summary>
        /// First Name of Customer
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name of Customer
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Total amount of money spent by Customer
        /// </summary>
        public decimal Total { get; set; }
    }
}
