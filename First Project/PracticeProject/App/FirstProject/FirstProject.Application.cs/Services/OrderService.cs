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
    public class OrderService : IOrderService
    {
        private readonly IOrderInterface _order;
        public OrderService(IOrderInterface  orderservice  )
        {
            _order = orderservice;
        }

        public async Task<ResponseModel<Order>> AddOrder(Order model)
        {
            await _order.CreateOrder(model);
            return ResponseModel<Order>.SuccessResponse(model, "Data Created Successfully");
        }

        public async Task<ResponseModel<bool>> DeleteOrder(Guid id)
        {
            var deletedata = await  _order.GetById(id);

            if (deletedata != null)
            {

                return ResponseModel<bool>.SuccessResponse(true, "Order deleted successfully");
            }

            return ResponseModel<bool>.FailureResponse("Order not found");
        }

        public  async Task<ResponseModel<OrderDTO>> GetAllCustomerOrder(Guid id)
        {
            var getall = await _order.GetAllCustomerOrder(id);
            return ResponseModel<OrderDTO>.SuccessResponse(getall);
        }

        public async Task<ResponseModel<List<Order>>> GetAllOrder()
        {
            var getlist = await _order.GetAll();
            var order = getlist.Select(a => new Order()
            {
                OrderNumber =a.OrderNumber,
             OrderDate =a.OrderDate,
             Quantity=a.Quantity,
             UnitPrice=a.UnitPrice,
             TotalAmount=a.TotalAmount,
            }).ToList();
            return ResponseModel<List<Order>>.SuccessResponse(order);
        }

        public async Task<ResponseModel<Order>> GetById(Guid id)
        {
            var order = await _order.GetById(id);
            if (order != null)
            {
                return ResponseModel<Order>.SuccessResponse(order, "Order found successfully");
            }
            return ResponseModel<Order>.FailureResponse("Order  not found");
        }

        public async Task<ResponseModel<Order>> UpdateOrder(Guid id, Order model)
        {
            var updateOrder = await _order.GetById(id);

            if (updateOrder == null)
            {
                return ResponseModel<Order>.FailureResponse("Order not found");

                updateOrder.OrderDate = model.OrderDate;
                updateOrder.OrderNumber = model.OrderNumber;
                updateOrder.Quantity=model.Quantity;
                await _order.UpdateOrder(updateOrder);
            }
            return ResponseModel<Order>.SuccessResponse(model, "Order updated successfully");
            throw new NotImplementedException();
        }

      
    }
    }
