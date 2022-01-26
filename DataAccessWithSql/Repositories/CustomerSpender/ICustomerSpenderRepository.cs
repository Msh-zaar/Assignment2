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
        Dictionary<CustomerSpender, decimal> GetHighSpenders();
    }
}
