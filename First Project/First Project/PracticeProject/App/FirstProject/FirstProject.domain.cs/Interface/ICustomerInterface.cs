using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Interface
{
   public  interface ICustomerInterface
    {
        Task<List<Customer>> GetAllCustomer();


        Task<Customer> GetById(int id);

        Task UpdateCustomer(Customer model);

        Task DeleteCustomer(Customer model);

        Task CreateCustomer(Customer model);
    }
}
