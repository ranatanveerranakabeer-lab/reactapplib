using FirstProject.Application.cs.Model;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using Microsoft.EntityFrameworkCore.Update.Internal;
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
        Task<ResponseModel<List<Order>>> GetAllOrderList(string productname, string customername, decimal quantity);
        Task<string> GetAlGenerateNewOrderNumberlOrder();
        Task<string> CreateOrderAsync(string customername, string productname, decimal quantity);
        //Task<ResponseModel <OrderDTO>> GetAllCustomerOrder(int id);
        Task<ResponseModel<Order>> GetById(int id);

        Task<ResponseModel<bool>> DeleteOrder(int id);

        Task<ResponseModel<Order>> UpdateOrder(int id, Order model);


        Task<ResponseModel<Order>> AddOrder(Order model);
    }
}
