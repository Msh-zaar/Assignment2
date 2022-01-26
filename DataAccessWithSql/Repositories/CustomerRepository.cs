﻿using DataAccessWithSql.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerlist = new List<Customer>();
            string sql = "SELECT TOP 5 CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                "OFFSET 2";
            try
            {
                //Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    Console.WriteLine("open");
                    //Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //Reader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Handle result
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = reader.GetString(1);
                                temp.LastName = reader.GetString(2);
                                temp.Country = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                                temp.PostalCode = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);
                                temp.Phone = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
                                temp.Email = reader.IsDBNull(6) ? "NULL" : reader.GetString(6);

                                customerlist.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("didnt load");
                 
            }
            return customerlist;
        }

        public Customer GetCustomer(string id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " + 
                "WHERE CustomerId = @CustomerId";
            try
            {
                //Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    Console.WriteLine("open");
                    //Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //Reader
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Handle result
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? "NULL" : reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("didnt load");

            }
            return customer;
        }
        Customer ICustomerRepository.GetCustomerByName(string name)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                "WHERE FirstName LIKE @FirstName";
            try
            {
                //Connect
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    Console.WriteLine("open");
                    //Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //Reader
                        cmd.Parameters.AddWithValue("@FirstName", name + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Handle result
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
                                customer.Email = reader.IsDBNull(6) ? "NULL" : reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Couldn't Load" + ex);

            }
            return customer;
        }
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            try
            {
                using (var conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    string sql = 
                        "INSERT INTO Customer (Firstname, LastName, Country, PostalCode, Phone, Email) " +
                        "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

                    conn.Open();
                    Console.WriteLine("open");
                    //Make a command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                        return success;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Couldn't Load" + ex);
            }
            return success;
        }

        public bool DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
