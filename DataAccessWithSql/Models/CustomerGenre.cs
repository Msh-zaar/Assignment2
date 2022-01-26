using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Models
{
    public class CustomerGenre
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string, int> MostListenedGenre { get; set; } = new Dictionary<string, int>();
    }
}
