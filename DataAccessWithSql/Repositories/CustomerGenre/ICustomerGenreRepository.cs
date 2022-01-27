using DataAccessWithSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public interface ICustomerGenreRepository
    {
        /// <summary>
        /// Returns a CustomerGenre object which contains the customers first and last names
        /// as well as a dictionary of their favourite genre(s) and the amount of times they've bought
        /// music of that genre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A CustomerGenre object</returns>
        public CustomerGenre GetMostPopularGenreForCustomer(string id);
    }
}
