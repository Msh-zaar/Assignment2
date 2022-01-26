using DataAccessWithSql.Models;
using DataAccessWithSql.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessWithSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CRUD
            //Create Read Update Delete

            ICustomerRepository repository = new CustomerRepository();
            ICustomerCountryRepository countryRepository = new CustomerCountryRepository();
            ICustomerSpenderRepository customerSpenderRepository = new CustomerSpenderRepository();
            //TestSelect(repository);
            //TestSelectAll(repository);
            //TestSelectByName(repository, "Hel");
            //TestSelectLimited(repository, 2, 5);
            //TestUpdate(repository);
            //TestInsert(repository);
            //TestSelectLimited(repository, 2, 5);
            //PrintDescendingCountries(countryRepository); 
            //PrintHighSpenders(customerSpenderRepository);

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
                Customer testCustomer = new Customer()
                {
                    FirstName = "Hans", 
                    LastName = "Hansen", 
                    Country = "Norway", 
                    PostalCode = "1363", 
                    Phone = "41500594", 
                    Email = @"HansHansen@sol.no"
                };
                if (repository.AddNewCustomer(testCustomer))
                {
                    Console.WriteLine("yaya");
                } 
                else
                {
                    Console.WriteLine("naynay");
                }
            }

            static void TestUpdate(ICustomerRepository repository)
            {
                Customer test = new Customer()
                {
                    CustomerId = 2,
                    FirstName = "Jon",
                    LastName = "Johnson",
                    Country = "Norway",
                    PostalCode = "0169",
                    Phone = "12332112",
                    Email = "jon.johnson@piczo.com"
                };
                if (repository.UpdateCustomer(test))
                {
                    Console.WriteLine("yaya");
                    PrintCustomer(repository.GetCustomer(test.CustomerId.ToString()));
                }
                else
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

            static void PrintDescendingCountries(ICustomerCountryRepository repository)
            {
                repository.GetCountriesDescendingOrder()
                    .Select(i => $"{i.Key}: {i.Value}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            }

            static void PrintHighSpenders(ICustomerSpenderRepository repository)
            {
                repository.GetHighSpenders()
                    .Select(i => $"{i.Key.FirstName} {i.Key.LastName}: {i.Value}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
        private static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"-- {customer.CustomerId} " +
                                $"{customer.FirstName} " +
                                $"{customer.LastName} " +
                                $"{customer.Country} " +
                                $"{customer.PostalCode} " +
                                $"{customer.Phone} " +
                                $"{customer.Email} --");
        }
    }
}
