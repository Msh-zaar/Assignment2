using DataAccessWithSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessWithSql.Repositories
{
    public interface ICustomerRepository
    {
        //CRUD
        /// <summary>
        /// Retrieves a single customer from the database based on CustomerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specific Customer</returns>
        public Customer GetCustomer(string id);
        /// <summary>
        /// Retrieves a single customer from the database based on FirstName
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A specific Customer</returns>
        public Customer GetCustomerByName(string name);
        /// <summary>
        /// Retrieves all customers from the database
        /// </summary>
        /// <returns>All Customers</returns>
        public List<Customer> GetAllCustomers();
        /// <summary>
        /// Retrieves a subset of all customers based on the given offset
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="fetch"></param>
        /// <returns>A List of Customers</returns>
        public List<Customer> GetLimitedCustomers(int offset, int fetch);
        /// <summary>
        /// Adds a new customer to the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true if success, false if not</returns>
        public bool AddNewCustomer(Customer customer);
        /// <summary>
        /// Updates an existing customer in the database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>true if success, false if not</returns>
        public bool UpdateCustomer(Customer customer);
        /// <summary>
        /// Deletes a customer from the database
        /// Not implemented
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if success, false if not</returns>
        public bool DeleteCustomer(string id);
    }
}
