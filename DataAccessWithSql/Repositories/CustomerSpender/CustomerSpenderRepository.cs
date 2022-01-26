using DataAccessWithSql.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public class CustomerSpenderRepository : ICustomerSpenderRepository
    {
        public Dictionary<CustomerSpender, decimal> GetHighSpenders()
        {
            Dictionary<CustomerSpender, decimal> highRollers = new();
            string sql = "SELECT Customer.CustomerId, Total, Customer.FirstName, Customer.LastName " +
                        "FROM Invoice " +
                        "INNER JOIN Customer " +
                        "ON Invoice.CustomerId = Customer.CustomerId " +
                        "ORDER BY Total DESC ";
            try
            {
                //Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    //Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender customer = new();
                                decimal total;
                                customer.CustomerId = reader.GetInt32(0);
                                total = reader.GetDecimal(1);
                                customer.FirstName = reader.GetString(2);
                                customer.LastName = reader.GetString(3);
                                highRollers[customer] = total;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Couldn't Load" + ex);
            }
            return highRollers;
        }
    }
}
