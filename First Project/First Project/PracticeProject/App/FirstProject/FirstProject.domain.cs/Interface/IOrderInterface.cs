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

        Task<Order> GetById(int id);
       
      //  Task <OrderDTO> GetAllCustomerOrder(int id);
        Task UpdateOrder(Order model);

        Task DeleteOrder(Order model);

        Task CreateOrder(Order model);   //create order ma method bna lia tha or create ki api bh bna giye thi ok ok//phly ya samjho ka guid jo id hy wo database ma aik do ki form ma save nhi hoti okey run kro project phly order create kro aik aik product create kro
        
    }
}
