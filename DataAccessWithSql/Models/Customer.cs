using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Models
{
    public class Customer
    {
        /// <summary>
        /// ID-number of Customer
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// First Name of Customer
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name of Customer
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Country the Customer lives in
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Postal Code of Customer
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Phone number of the Customer
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email address of the Customer
        /// </summary>
        public string Email { get; set; }

    }
}