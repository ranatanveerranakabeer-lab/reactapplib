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
    public class TransactionRepository : ITransactionInterface
    {
        private readonly DataContext _dataContext;
        private readonly IOrderInterface _order;
        //public readonly OrderService _orderService;
        public TransactionRepository(DataContext context, IOrderInterface order)
        {
            _dataContext = context;
            this._order = order;
        }

        public async Task AddAsync(TransactionData transaction)
        {
            //ransaction.Status = "Completed";
            //transaction.Remarks = "Transaction Complete";//orderid,amount,paymentmethod
            //transaction.ReferenceNumber = "10023";
            //transaction.CreatedAt = DateTime.Now;
            //transaction.CreatedBy = "created by sidra";
            //transaction.TaxAmount = 12;
            //transaction.DiscountAmount = 10;
            transaction.NetAmount = transaction.Amount + transaction.TaxAmount;
            await _dataContext.Transactions.AddAsync(transaction);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<TransactionData>> GetAllAsync()
        {
            return await _dataContext.Transactions.ToListAsync();
        }

        public async Task<TransactionData> GetByIdAsync(int date)
        {
            // var result=  await _dataContext.Transactions.FndAsync(id);
            var result = await _dataContext.Transactions.Where(t => t.TransactionDate == DateTime.Now).FirstOrDefaultAsync();
            return result;
        }


        public async Task<List<TransactionData>> GetByOrderIdAsync(int orderId)
        {
            return await _dataContext.Transactions
                .Where(t => t.OrderId == orderId)
                .ToListAsync();
        }


        public async Task<decimal?> GetTotalSalesAsync()
        {
            return await _dataContext.Transactions
                .Where(t => t.TransactionType == "Payment" && t.Status == "Completed")
                .SumAsync(t => t.NetAmount);
        }
    }
}
