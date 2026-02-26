using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Model;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Services
{
   public  class CustomerService : ICustomerService
    {
        private readonly ICustomerInterface _customerrepository;
        public CustomerService(ICustomerInterface customerService)
        {
            _customerrepository = customerService;
        }

        public  async Task<ResponseModel<Customer>> AddCustomer(Customer model)
        {
            await _customerrepository.CreateCustomer(model);
            return ResponseModel<Customer>.SuccessResponse(model, "Data Created Successfully");
        }

        public async Task<ResponseModel<bool>> DeleteCustomer(Guid id)
        {
            var deletedata = await _customerrepository.GetById(id);

            if (deletedata != null)
            {

                return ResponseModel<bool>.SuccessResponse(true, "Customer deleted successfully");
            }

            return ResponseModel<bool>.FailureResponse("Customer not found");
        }

        public async Task<ResponseModel<List<Customer>>> GetAllCustomer()
        {
            var getlist = await _customerrepository.GetAllCustomer();
            var customer = getlist.Select(a => new Customer()
            {
                Name =a.Name,
              Phone =a.Phone,
              Email=a.Email,
            }).ToList();
            return ResponseModel<List<Customer>>.SuccessResponse(customer);
        }

        public async Task<ResponseModel<Customer>> GetById(Guid id)
        {
            var customer = await _customerrepository.GetById(id);
            if (customer != null)
            {
                return ResponseModel<Customer>.SuccessResponse(customer, "Customer found successfully");
            }
            return ResponseModel<Customer>.FailureResponse("Customer  not found");
        }

        public async Task<ResponseModel<Customer>> UpdateCustomer(Guid id, Customer model)
        {
            var updateCustomer = await _customerrepository.GetById(id);
            
            if (updateCustomer == null)
            {
                return ResponseModel<Customer>.FailureResponse("Customer not found");
                
                updateCustomer.Name = model.Name;
                updateCustomer.Phone = model.Phone;
                updateCustomer.Email=model.Email;   
                await _customerrepository.UpdateCustomer(updateCustomer);
            }
            return ResponseModel<Customer>.SuccessResponse(model, "Customer updated successfully");
            throw new NotImplementedException();
        }
    }
    }
