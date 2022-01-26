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

        //SELECT Customer.CustomerId, COUNT(Customer.CustomerId) as Count, Genre.Name
        //FROM InvoiceLine
        //INNER JOIN Invoice
        //ON InvoiceLine.InvoiceId = Invoice.InvoiceId
        //INNER JOIN Track
        //ON InvoiceLine.TrackId = Track.TrackId
        //LEFT JOIN Customer
        //ON Invoice.CustomerId = Customer.CustomerId
        //LEFT JOIN Genre
        //ON Track.GenreId = Genre.GenreId
        //WHERE Customer.CustomerId = 1
        //GROUP BY Genre.Name, Customer.CustomerId
        //ORDER BY Count DESC
    }
}
