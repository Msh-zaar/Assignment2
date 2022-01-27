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

            //Repositories
            ICustomerRepository repository = new CustomerRepository();
            ICustomerCountryRepository countryRepository = new CustomerCountryRepository();
            ICustomerSpenderRepository customerSpenderRepository = new CustomerSpenderRepository();
            ICustomerGenreRepository customerGenreRepository = new CustomerGenreRepository();

            //Calling test methods
            TestSelectAll(repository);
            TestSelect(repository);
            TestSelectByName(repository, "Hel");
            TestSelectLimited(repository, 2, 5);
            TestInsert(repository);
            TestUpdate(repository);
            TestDescendingCountries(countryRepository); 
            TestHighSpenders(customerSpenderRepository);
            TestCustomerGenre(customerGenreRepository);

            //Test method bodies
            static void TestSelectAll(ICustomerRepository repository)
            {
                Console.WriteLine("TestSelectAll:");
                PrintCustomers(repository.GetAllCustomers());
            }
            static void TestSelect(ICustomerRepository repository)
            {
                Console.WriteLine("TestSelect:");
                PrintCustomer(repository.GetCustomer("1"));
            }
            static void TestSelectLimited(ICustomerRepository repository, int offset, int fetch)
            {
                Console.WriteLine("TestSelectLimited:");
                PrintCustomers(repository.GetLimitedCustomers(offset, fetch));

            }
            static void TestSelectByName(ICustomerRepository repository, string name)
            {
                Console.WriteLine("TestSelectByName:");
                PrintCustomer(repository.GetCustomerByName(name));
            }
            static void TestInsert(ICustomerRepository repository)
            {
                Console.WriteLine("TestInsert:");
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
                    Console.WriteLine("Insert Successful!");
                } 
                else
                {
                    Console.WriteLine("Insert Failed!");
                }
            }
            static void TestUpdate(ICustomerRepository repository)
            {
                Console.WriteLine("TestUpdate:");
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
                    Console.WriteLine("Update Successful!");
                    PrintCustomer(repository.GetCustomer(test.CustomerId.ToString()));
                }
                else
                {
                    Console.WriteLine("Update Failed!");
                }
            }
            static void TestDescendingCountries(ICustomerCountryRepository repository)
            {
                Console.WriteLine("TestDescendingCountries:");
                PrintCustomerCountry(repository.GetCountriesDescendingOrder());
            }
            static void TestHighSpenders(ICustomerSpenderRepository repository)
            {
                Console.WriteLine("TestHighSpenders:");
                PrintCustomerSpender(repository.GetHighSpenders());
            }
            static void TestCustomerGenre(ICustomerGenreRepository repository)
            {
                Console.WriteLine("TestCustomerGenre:");
                PrintCustomerGenre(repository.GetMostPopularGenreForCustomer("1"));
                PrintCustomerGenre(repository.GetMostPopularGenreForCustomer("12")); // Multiple favourite genres
            }
        }
        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }
        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerId} " +
                                $"{customer.FirstName} " +
                                $"{customer.LastName} " +
                                $"{customer.Country} " +
                                $"{customer.PostalCode} " +
                                $"{customer.Phone} " +
                                $"{customer.Email}");
        }
        static void PrintCustomerCountry(List<CustomerCountry> customerCountry)
        {
            customerCountry.Select(i => $"{i.Name}: {i.Count}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
        static void PrintCustomerSpender(List<CustomerSpender> customerSpender)
        {
            customerSpender.Select(i => $"{i.FirstName} {i.LastName}: {i.Total}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
        static void PrintCustomerGenre(CustomerGenre customerGenre)
        {
            Console.WriteLine($"{customerGenre.FirstName} {customerGenre.LastName}: ");
            customerGenre.MostListenedGenre.Select(i => $"{i.Key}: {i.Value}")
                    .ToList()
                    .ForEach(Console.WriteLine);
        }
    }
}
