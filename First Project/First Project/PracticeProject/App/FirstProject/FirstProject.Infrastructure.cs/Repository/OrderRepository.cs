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
    public class OrderRepository : IOrderInterface
    {
        private readonly DataContext _dataContext;
        public OrderRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task CreateOrder(Order model)
        {
            await _dataContext.Orders.AddAsync(model);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(Order model)
        {
            var order = await _dataContext.Orders.FirstOrDefaultAsync(x => x.Id==model.Id);
            if (order!=null)
            {
                _dataContext.Orders.Remove(order);
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task<List<Order>> GetAll()
        {
            return await _dataContext.Orders.ToListAsync();

        }

      
        //    public async Task<OrderDTO> GetAllCustomerOrder(int id)
        //{
        //    var orders = await _dataContext.Orders
        //        .Join(_dataContext.Customers,
        //            o => o.CustomerId,
        //            c => c.Id,
        //            (o, c) => new { o, c })
        //        .Join(_dataContext.Products,
        //            oc => oc.o.ProductId,
        //            p => p.Id,
        //            (oc, p) => new OrderDTO
        //            {
        //                OrderNumber = oc.o.OrderNumber,
        //                CustomerName = oc.c.Name,
        //                ProductName = p.Name,
        //                Quantity = oc.o.Quantity,
        //                TotalAmount = oc.o.TotalAmount
        //            })
        //        .FirstOrDefaultAsync();

        //    return orders;
        //}

         
       

        public async Task<Order?> GetById(int id)
        {
            return await _dataContext.Orders.FindAsync(id);
        }

        public async Task UpdateOrder(Order model)
        {
            var order = await _dataContext.Orders.FirstOrDefaultAsync(x => x.Id==model.Id);
            if (order!=null)
            {
                order.OrderNumber=model.OrderNumber;
                order.OrderDate=model.OrderDate;
                order.Quantity=model.Quantity;
                order.UnitPrice=model.UnitPrice;
                order.Productname=model.Productname;
                order.Customername=model.Customername;

                _dataContext.Update(order);
                await _dataContext.SaveChangesAsync();
            }
        }

    }
}