using FirstProject.domain.cs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.domain.cs.Interface
{
    public interface IOrderInterface
    {
        Task<List<Order>> GetAll();


        Task<Order> GetById(Guid id);

        Task <OrderDTO> GetAllCustomerOrder(Guid id);
        Task UpdateOrder(Order model);

        Task DeleteOrder(Order model);

        Task CreateOrder(Order model);

    }
}
