using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InfrastructureLayer.Data;

namespace InfrastructureLayer.Repositories
{

    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        Customer Find(int id);
        List<Customer> GetAll();
    }

    public class CustomerRepository : ICustomerRepository 
    {
        protected readonly HotelDBContext _context;
        public CustomerRepository(HotelDBContext dbContext)
        {
            _context = dbContext;
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var exist = _context.Customers.Find(id);
            if (exist == null)
                return;

            _context.Entry(exist).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Customer Find(int id)
        {
            return _context.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}