using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Models
{
    public class MockCustomer : ICustomerRepository
    {
        private List<Customer> _listOfCustomers;

        public MockCustomer()
        {

            _listOfCustomers = new List<Customer>()
            {
                new Customer(){Id=1, Name="Mary Thomas", Email="mary@gmail.com", Gender=Gender.Female},
                new Customer(){Id=2, Name="John Brown", Email="john@outlook.com", Gender=Gender.Male}
            };
        }
        public Customer GetCustomer(int id)
        {
            return _listOfCustomers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetListOfCustomers()
        {
            return _listOfCustomers;
        }

        public Customer AddNewCustomer(Customer customer)
        {
            customer.Id = _listOfCustomers.Max(x => x.Id) + 1;
            _listOfCustomers.Add(customer);
            return customer;
        }

        public Customer Delete(int id)
        {
            Customer customer = _listOfCustomers.FirstOrDefault(x => x.Id == id);
            if(customer != null)
            {
                _listOfCustomers.Remove(customer);
            }
            return customer;
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            Customer customer = _listOfCustomers.FirstOrDefault(x => x.Id == updatedCustomer.Id);
            if(customer != null)
            {
                customer.Name = updatedCustomer.Name;
                customer.Email = updatedCustomer.Email;
                customer.Gender = updatedCustomer.Gender;
            }
            return customer;
        }
    }
}
