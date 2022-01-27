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
        public List<CustomerSpender> GetHighSpenders()
        {
            List<CustomerSpender> spenders = new List<CustomerSpender>();
            string sql = "SELECT Total, Customer.FirstName, Customer.LastName " +
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
                                CustomerSpender customerSpender = new CustomerSpender();
                                customerSpender.Total = reader.GetDecimal(0);
                                customerSpender.FirstName = reader.GetString(1);
                                customerSpender.LastName = reader.GetString(2);
                                spenders.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Couldn't Load" + ex);
            }
            return spenders;
        }
    }
}
