﻿using DataAccessWithSql.Models;
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
            TestSelectAll(repository);
            //TestSelect(repository);

            static void TestSelectAll(ICustomerRepository repository)
            {
                PrintCustomers(repository.GetAllCustomers());
               
            } 

            static void TestSelect(ICustomerRepository repository)
            {
                PrintCustomer(repository.GetCustomer("1"));
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
            Console.WriteLine($"--{customer.Id} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.PhoneNumber} {customer.Email} --");
        }
    }
}