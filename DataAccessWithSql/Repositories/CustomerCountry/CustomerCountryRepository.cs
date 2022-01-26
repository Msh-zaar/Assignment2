﻿using DataAccessWithSql.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public class CustomerCountryRepository : ICustomerCountryRepository
    {
        public Dictionary<CustomerCountry, int> GetCountriesDescendingOrder()
        {
            Dictionary<CustomerCountry, int> countries = new();

            string sql = "SELECT Country, count(*) as Count " +
                        "FROM Customer " +
                        "GROUP BY Country " +
                        "ORDER BY Count DESC";
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
                                CustomerCountry customerCountry = new CustomerCountry();
                                customerCountry.Name = reader.GetString(0);
                                var count = reader.GetInt32(1);
                                countries[customerCountry] = count;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Couldn't Load" + ex);

            }
            return countries;
        }
    }
}