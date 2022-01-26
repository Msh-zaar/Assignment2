using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Models
{
    public class CustomerGenre
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public int AmountListened { get; set; }
    }
}
