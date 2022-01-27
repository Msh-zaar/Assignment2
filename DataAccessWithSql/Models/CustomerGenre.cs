using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Models
{
    public class CustomerGenre
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
        /// Dictionary of the genres the Customer listens to the most
        /// Key = genre
        /// Value = times the customer bought music of the genre
        /// </summary>
        public Dictionary<string, int> MostListenedGenre { get; set; } = new Dictionary<string, int>();
    }
}
