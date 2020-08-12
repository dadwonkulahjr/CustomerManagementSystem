using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Models
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetListOfCustomers();
        Customer AddNewCustomer(Customer customer);
        Customer Delete(int id);
        Customer UpdateCustomer(Customer updatedCustomer);


    }
}
