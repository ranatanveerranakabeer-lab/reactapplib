using FirstProject.Application.cs.Interface;
using FirstProject.Application.cs.Model;
using FirstProject.domain.cs.Entities;
using FirstProject.domain.cs.Interface;
using FirstProject.Infrastructure.cs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Application.cs.Services
{
    public class OrderService : IOrderService//isma dakho kia mismatch hy thk kro//iservice ka andr jao na
    {
        private readonly IOrderInterface _order;
        private readonly IProductInterface _product;
        private readonly DataContext _dataContext;


        public OrderService(IOrderInterface  orderservice, DataContext dataContext)//agie hy samjh aik mint
        {
            _order = orderservice;
            _dataContext = dataContext;
        }

        public async Task<ResponseModel<Order>> AddOrder(Order model)
        {
            await _order.CreateOrder(model);
            return ResponseModel<Order>.SuccessResponse(model, "Data Created Successfully");
        }

        public async Task<string> CreateOrderAsync(string productname, string customername, decimal quantity)  
        {
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Name ==customername ); 
            var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Name ==productname ); 

            if (product.StockQuantity < quantity)
                return "Stock Not Available";

            if (customer == null)
                return "Customer Not Found";
            if (product == null)
                return "Product Not Found";

            var ordernumber = await GetAlGenerateNewOrderNumberlOrder();

            var orderlist = new Order
            { 
                OrderNumber = ordernumber,
                Customername = customer.Name,
                Productname = product.Name,
                Quantity = quantity,
                UnitPrice = product.Price,
                TotalAmount = quantity * product.Price,
                OrderDate = DateTime.Now,
               
            };

            product.StockQuantity -= quantity;

            await _order.CreateOrder(orderlist);

            return "Order Created Successfully";
        }
        //ab dakho screen show horahi hy apko hmm okey acha hmny order ka method yani interface bna liya tha ap ny//kro ab kro
        //
      
        public async Task<ResponseModel<bool>> DeleteOrder(int id)
        {
            var deletedata = await  _order.GetById(id);

            if (deletedata != null)
            {

                return ResponseModel<bool>.SuccessResponse(true, "Order deleted successfully");
            }

            return ResponseModel<bool>.FailureResponse("Order not found");
        }

        //public async Task<string> GetAlGenerateNewOrderNumberlOrder()
        //{
        //    var orderlist = await _dataContext.Orders.OrderByDescending(o => o.Id).LastOrDefaultAsync();

        //    if (orderlist == null)
        //    {
        //        return "1001";
        //    }

        //    int ordernumber = int.Parse(orderlist.OrderNumber);


        //    return (ordernumber + 1).ToString();
        //}
        public async Task<string> GetAlGenerateNewOrderNumberlOrder()
        {
            int ordernumber;

            var orderlist = await _dataContext.Orders.OrderByDescending(o => o.Id).FirstOrDefaultAsync();

            if (orderlist == null)
            
                return "1001";
            else
            {
                ordernumber = int.Parse(orderlist.OrderNumber) +1;
            }

               


            return (ordernumber).ToString();
        }
        //public  async Task<ResponseModel<OrderDTO>> GetAllCustomerOrder(int ID)
        //{
        //    var getall = await _order.GetAllCustomerOrder(ID);
        //    return ResponseModel<OrderDTO>.SuccessResponse(getall);
        //}

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

        public async Task<ResponseModel<Order>> GetById(int id)
        {
            var order = await _order.GetById(id);
            if (order != null)
            {
                return ResponseModel<Order>.SuccessResponse(order, "Order found successfully");
            }
            return ResponseModel<Order>.FailureResponse("Order  not found");
        }

        public async Task<ResponseModel<Order>> UpdateOrder(int id, Order model)//hogia hy hmm okey aj laptop perfect hy mery wala thk h //btao kia iisue hy//call pr ajao sath okk//
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

        public async Task<ResponseModel<List<Order>>> GetAllOrderList(string productname, string customername, decimal quantity)  //ya wala nhi dakha tha hmm dkha thaa//okey
        {
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Name == customername);
            var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Name == productname);

            if (product.StockQuantity < quantity)//ai samjh agr product ma stock kaam hoga to kasy order place hoga ok
                return ResponseModel<List<Order>>.FailureResponse( "no stock available");

            if (customer == null)
                return ResponseModel<List<Order>>.FailureResponse("no customer found");
            if (product == null)
                return ResponseModel<List<Order>>.FailureResponse("no product found");

           
            List<Order> orderListData = new List<Order>();
            var ordernumber = await GetAlGenerateNewOrderNumberlOrder();
             int listorder=int.Parse(ordernumber);

            var orderlist1 = new Order
            {
                OrderNumber = listorder.ToString(),
                Customername = customer.Name,
                Productname = product.Name,
                Quantity = quantity,
                UnitPrice = product.Price,
                TotalAmount = quantity * product.Price,
                OrderDate = DateTime.Now,

            };
            //var ordernumber1 = await GetAlGenerateNewOrderNumberlOrder();  //ab thk hy hmmm dakhy run krka mhm   //sidra dear phir kl krty hy isko ap ny hm ny jo increment wala method bnaya hy isko dakhna hy isko kl dobara revise krly gy oky //aor ma zip ap ko send krta hn  ok//thk hy phir hmm
            var orderlist2 = new Order
            {
                OrderNumber = (listorder +1).ToString(),
                Customername = customer.Name,
                Productname = product.Name,
                Quantity = quantity,
                UnitPrice = product.Price,
                TotalAmount = quantity * product.Price,
                OrderDate = DateTime.Now,

            };
            product.StockQuantity -= quantity;

            orderListData.Add(orderlist1);
            orderListData.Add(orderlist2);
            await _order.CreateOrder(orderlist1);
            await _order.CreateOrder(orderlist2);

            return ResponseModel<List<Order>>.SuccessResponse(orderListData,"no product found");
        }

        
    }
    }
