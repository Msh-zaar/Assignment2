using DataAccessWithSql.Models;
using DataAccessWithSql.Repositories;
using System;
using System.Collections.Generic;

namespace DataAccessWithSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CRUD
            //Create Read Update Delete

            ICustomerRepository repository = new CustomerRepository();
            //TestSelect(repository);
            //TestSelectAll(repository);
            //TestSelectByName(repository, "Hel");
            TestSelectLimited(repository, 2, 5);
            

            static void TestSelectAll(ICustomerRepository repository)
            {
                PrintCustomers(repository.GetAllCustomers());
            }

            static void TestSelectLimited(ICustomerRepository repository, int offset, int fetch)
            {
                PrintCustomers(repository.GetLimitedCustomers(offset, fetch));

            }

            static void TestSelect(ICustomerRepository repository)
            {
                PrintCustomer(repository.GetCustomer("1"));
            }

            static void TestSelectByName(ICustomerRepository repository, string name)
            {
                PrintCustomer(repository.GetCustomerByName(name));
            }

            static void TestInsert(ICustomerRepository repository)
            {
                Customer test = new Customer()
                {
                    //Name = "Brie Larson",
                    //Alias = "Captain Marvel",
                    //Origin = "Space"
                };
                if (repository.AddNewCustomer(test))
                {
                    Console.WriteLine("yaya");
                } else
                {
                    Console.WriteLine("naynay");
                }
            }
             
            static void PrintCustomers(IEnumerable<Customer> customers)
            {
                foreach (Customer customer in customers)
                {
                    PrintCustomer(customer);
                }
            }
        }

        private static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"-- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} --");
        }
    }
}
