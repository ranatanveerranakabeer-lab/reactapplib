
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Infrastructure.cs.Repository
{
   public  class CustomerRepository:ICustomerInterface
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext dataContext )
        {
           _context = dataContext; 
        }

        public async Task CreateCustomer(Customer model)
        {
         await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Customer model)
        {
            var deletedata = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (deletedata != null)
            {
                _context.Customers.Remove(deletedata);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            var customers = await _context.Customers.OrderBy(c => c.Name)
     .ToListAsync();
            return customers;
        }

        public async Task<Customer> GetById(Guid id)
        {
           return  await _context.Customers.FindAsync(id);

        }

        public async Task UpdateCustomer(Customer model)
        {
            var updatedata = await _context.Customers.FirstOrDefaultAsync(x => x.Id==model.Id);
            if (updatedata!=null)
            {

                updatedata.Id=model.Id;
                updatedata.Name=model.Name;
                updatedata.Phone=model.Phone;
                updatedata.Email=model.Email;
                
                _context.Customers.Update(updatedata);
                await _context.SaveChangesAsync();
            }

        }

       
    }
}
