using FirstProject.Application.cs.Model;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Interface
{
   public  interface IOrderService
    {
        Task<ResponseModel<List<Order>>> GetAllOrder();

        Task<ResponseModel <OrderDTO>> GetAllCustomerOrder(Guid id);
        Task<ResponseModel<Order>> GetById(Guid id);

        Task<ResponseModel<bool>> DeleteOrder(Guid id);

        Task<ResponseModel<Order>> UpdateOrder(Guid id, Order model);


        Task<ResponseModel<Order>> AddOrder(Order model);
    }
}
