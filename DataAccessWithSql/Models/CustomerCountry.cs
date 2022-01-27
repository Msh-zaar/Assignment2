using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Models
{
    public class CustomerCountry
    {
        /// <summary>
        /// Name of the Country
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Number of appearances of Country in database
        /// </summary>
        public int Count { get; set; }
    }
}
