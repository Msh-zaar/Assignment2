using DataAccessWithSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public interface ICustomerCountryRepository
    {
        /// <summary>
        /// Retrieves a list of CustomerCountry objects which contain 
        /// the name of the country and the amount of times it appears in the dataset
        /// </summary>
        /// <returns>A List of CustomerCountry objects</returns>
        public List<CustomerCountry> GetCountriesDescendingOrder();
    }
}
