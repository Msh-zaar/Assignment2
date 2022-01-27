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
            TestSelectLimited(repository, 2, 5);
            TestSelectByName(repository, "Hel"); //Returns Helena
            TestInsert(repository);
            TestUpdate(repository);
            TestDescendingCountries(countryRepository);
            TestHighSpenders(customerSpenderRepository);
            TestCustomerGenre(customerGenreRepository);

            //Test method bodies

            //Task 1
            static void TestSelectAll(ICustomerRepository repository)
            {
                Console.WriteLine("TestSelectAll:");
                PrintCustomers(repository.GetAllCustomers());
            }

            //Task 2
            static void TestSelect(ICustomerRepository repository)
            {
                Console.WriteLine("\n TestSelect:");
                PrintCustomer(repository.GetCustomer("1"));
            }

            //Task 3
            static void TestSelectByName(ICustomerRepository repository, string name)
            {
                Console.WriteLine("\n TestSelectByName:");
                PrintCustomer(repository.GetCustomerByName(name));
            }

            //Task 4
            static void TestSelectLimited(ICustomerRepository repository, int offset, int fetch)
            {
                Console.WriteLine("\n TestSelectLimited:");
                PrintCustomers(repository.GetLimitedCustomers(offset, fetch));

            }

            //Task 5
            static void TestInsert(ICustomerRepository repository)
            {
                Console.WriteLine("\n TestInsert:");
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

            //Task 6
            static void TestUpdate(ICustomerRepository repository)
            {
                Console.WriteLine("\n TestUpdate:");
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

            //Task 7
            static void TestDescendingCountries(ICustomerCountryRepository repository)
            {
                Console.WriteLine("\n TestDescendingCountries:");
                PrintCustomerCountry(repository.GetCountriesDescendingOrder());
            }

            //Task 8
            static void TestHighSpenders(ICustomerSpenderRepository repository)
            {
                Console.WriteLine("\n TestHighSpenders:");
                PrintCustomerSpender(repository.GetHighSpenders());
            }

            //Task 9
            static void TestCustomerGenre(ICustomerGenreRepository repository)
            {
                Console.WriteLine("\n TestCustomerGenre:");
                PrintCustomerGenre(repository.GetMostPopularGenreForCustomer("1"));
                PrintCustomerGenre(repository.GetMostPopularGenreForCustomer("12")); // Multiple favourite genres
            }
        }

        /// <summary>
        /// Loops through an IEnumerable<Customer> and calls PrintCustomer on each element
        /// </summary>
        /// <param name="customers"></param>
        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        /// <summary>
        /// Prints relevant attributes of a Customer
        /// </summary>
        /// <param name="customer"></param>
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

        /// <summary>
        /// Prints name and count of all CustomerCountry
        /// </summary>
        /// <param name="customerCountry"></param>
        static void PrintCustomerCountry(List<CustomerCountry> customerCountry)
        {
            customerCountry.Select(i => $"{i.Name}: {i.Count}")
                .ToList()
                .ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Prints first name, last name and total money spent of all CustomerSpender
        /// </summary>
        /// <param name="customerSpender"></param>
        static void PrintCustomerSpender(List<CustomerSpender> customerSpender)
        {
            customerSpender.Select(i => $"{i.FirstName} {i.LastName}: {i.Total}")
                .ToList()
                .ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Prints first name, last name, genre and amount of times songs of the genre have been bought
        /// </summary>
        /// <param name="customerGenre"></param>
        static void PrintCustomerGenre(CustomerGenre customerGenre)
        {
            Console.WriteLine($"{customerGenre.FirstName} {customerGenre.LastName}: ");
            customerGenre.MostListenedGenre.Select(i => $"{i.Key}: {i.Value}")
                    .ToList()
                    .ForEach(Console.WriteLine);
        }
    }
}
