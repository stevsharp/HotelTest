using System;
using ApplicationLayer.Customer;
using ApplicationLayer.DTO;
using HotelClient.Controllers;
using InfrastructureLayer.Data;
using InfrastructureLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelClient.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void Create()
        {
            ICustomerRepository customerRepository = new CustomerRepository(new HotelDBContext());

            ICustomerService customerService = new CustomerService(customerRepository);

            var controller = new CustomerController(customerService);
            // Act
            controller.PostCustomer(new  CustomerDTO() { HotelID = 2 , Name = "Test Customer " , LastName = "Test LastName" , NumberOfPax = 1} );
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Update()
        {
            ICustomerRepository customerRepository = new CustomerRepository(new HotelDBContext());

            ICustomerService customerService = new CustomerService(customerRepository);

            var controller = new CustomerController(customerService);
            // Act
            controller.PutCustomer(1,new CustomerDTO() { HotelID = 2, Name = "Test Customer 1", LastName = "Test LastName 1", NumberOfPax = 1 });
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            ICustomerRepository customerRepository = new CustomerRepository(new HotelDBContext());

            ICustomerService customerService = new CustomerService(customerRepository);

            var controller = new CustomerController(customerService);
            // Act
            controller.DeleteCustomer(1);
        }
    }

    
}
