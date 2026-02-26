using FirstProject.Application.cs.Model;
using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Interface
{
   public interface  ICustomerService
    {
        Task<ResponseModel<List<Customer>>> GetAllCustomer();

        Task<ResponseModel<Customer>> GetById(int id);

        Task<ResponseModel<bool>> DeleteCustomer(int id);

        Task<ResponseModel<Customer>> UpdateCustomer(int id, Customer model);


        Task<ResponseModel<Customer>> AddCustomer(Customer model);
    }
}
