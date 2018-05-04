using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.DTO;

namespace ApplicationLayer.Customer
{
    public interface ICustomerService
    {
        bool CreateCustomer(CustomerDTO hotel);

        bool UpdateCustomer(int id, CustomerDTO hotel);

        bool DeleteCustomer(int id);

        CustomerDTO GetByID(int id);

        IEnumerable<CustomerDTO> GetAll();
    }
}
