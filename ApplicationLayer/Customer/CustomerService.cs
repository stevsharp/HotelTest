using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLayer.DTO;
using ApplicationLayer.Hotel;
using InfrastructureLayer.Repositories;

namespace ApplicationLayer.Customer
{
    public class CustomerService : ICustomerService
    {

        protected readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public bool CreateCustomer(CustomerDTO customer)
        {
            try
            {
                _customerRepository.CreateCustomer(new InfrastructureLayer.Data.Customer()
                {
                    HotelID = customer.HotelID , 
                    LastName = customer.LastName ,
                    Name = customer.Name, 
                    NumberOfPax = customer.NumberOfPax
                });
            }
            catch (Exception e)
            {
                // Do Some Loggoing
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(int id, CustomerDTO customer)
        {
            try
            {
                var editCustomer = _customerRepository.Find(id);
                if (editCustomer == null)
                    return false;

                editCustomer.HotelID = customer.HotelID;
                editCustomer.Id = id;
                editCustomer.LastName = customer.LastName;
                editCustomer.Name = customer.Name;
                editCustomer.NumberOfPax = customer.NumberOfPax;

                _customerRepository.UpdateCustomer(editCustomer);
            }
            catch (Exception e)
            {
                // Do Some Loggoing
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
            }
            catch (Exception e)
            {
                // Do Some Loggoing
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerDTO GetByID(int id)
        {
            var customer = _customerRepository.Find(id);
            if (customer != null)
            {
                return new CustomerDTO()
                {
                    Name = customer.Name ,
                    HotelID = customer.HotelID,
                    NumberOfPax =  customer.NumberOfPax,
                    LastName = customer.LastName
                };
            }

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerDTO> GetAll()
        {
            var customers = _customerRepository.GetAll();

            foreach (var customer in customers)
                yield return new CustomerDTO()
                {
                    Name = customer.Name,
                    HotelID = customer.HotelID,
                    NumberOfPax = customer.NumberOfPax,
                    LastName = customer.LastName
                };

        }
    }
}