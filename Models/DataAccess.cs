using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Models
{
    public class DataAccess : ICustomerRepository
    {
        private readonly SQLDbContext _context;

        public DataAccess(SQLDbContext context)
        {
            _context = context;
        }
        public Customer AddNewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer Delete(int id)
        {
            var employee = _context.Customers.Find(id);
            if(employee != null)
            {
                _context.Customers.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetListOfCustomers()
        {
            return _context.Customers;
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            var customer = _context.Customers.Attach(updatedCustomer);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatedCustomer;
        }
    }
}
