using DataAccessWithSql.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public class CustomerGenreRepository : ICustomerGenreRepository
    {
        public CustomerGenre GetMostPopularGenreForCustomer(string id)
        {
            CustomerGenre customerGenre = new();
            string sql =
                "SELECT Customer.FirstName, Customer.LastName, COUNT(Customer.CustomerId) as Count, Genre.Name " +
                "FROM InvoiceLine " +
                "INNER JOIN Invoice " +
                "ON InvoiceLine.InvoiceId = Invoice.InvoiceId " +
                "INNER JOIN Track " +
                "ON InvoiceLine.TrackId = Track.TrackId " +
                "LEFT JOIN Customer " +
                "ON Invoice.CustomerId = Customer.CustomerId " +
                "LEFT JOIN Genre " +
                "ON Track.GenreId = Genre.GenreId " +
                "WHERE Customer.CustomerId = @CustomerId " +
                "GROUP BY Genre.Name, Customer.FirstName, Customer.LastName " +
                "ORDER BY Count DESC";
            try
            {
                //Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //Command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        //Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerGenre.FirstName = reader.GetString(0);
                                customerGenre.LastName = reader.GetString(1);                              
                                int amount = reader.GetInt32(2);
                                string genre = reader.GetString(3);
                                if (customerGenre.MostListenedGenre.Count == 0)
                                {
                                    customerGenre.MostListenedGenre[genre] = amount;
                                }
                                if (customerGenre.MostListenedGenre.Values.Max() == amount)
                                {
                                    customerGenre.MostListenedGenre[genre] = amount;
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Couldn't Load" + ex);

            }
            return customerGenre;
        }
    }
}
